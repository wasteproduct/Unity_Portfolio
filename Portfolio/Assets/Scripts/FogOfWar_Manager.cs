using System.Collections.Generic;
using UnityEngine;

public class FogOfWar_Manager : MonoBehaviour
{
    [SerializeField]
    private int textureSize = 256;
    [SerializeField]
    private Color fogOfWarColor;
    [SerializeField]
    private LayerMask fogOfWarLayer;
    [SerializeField]
    private Variable_Int currentTileX;
    [SerializeField]
    private Variable_Int currentTileZ;

    private Texture2D fogOfWarTexture;
    private Color[] pixels;
    private List<FogOfWar_Revealer> revealers;
    private int pixelsPerUnit;
    private Vector2 centerPixel;

    private int tilesRow, tilesColumn;

    public static FogOfWar_Manager Instance { get; private set; }

    // 여기
    public void RevealArea()
    {
        int revealedDistance = revealers[0].RevealedDistance;

        for(int z=currentTileZ.value-revealedDistance;z<=currentTileZ.value+revealedDistance;z++)
        {
            if ((z < 0) || (z >= tilesColumn)) continue;

            for(int x=currentTileX.value-revealedDistance;x<=currentTileX.value+revealedDistance;x++)
            {
                if ((x < 0) || (x >= tilesRow)) continue;
            }
        }
    }

    public void Initialize(int rowSize, int columnSize)
    {
        tilesRow = rowSize;
        tilesColumn = columnSize;

        transform.position = new Vector3(tilesRow / 2, 5.0f, tilesColumn / 2);
        transform.localScale *= tilesColumn * 1.28f;

        Instance = this;

        Renderer renderer = GetComponent<Renderer>();
        Material material = null;
        material = renderer.material;

        if (material == null) print("Material is null");

        fogOfWarTexture = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, false)
        {
            wrapMode = TextureWrapMode.Clamp
        };

        pixels = fogOfWarTexture.GetPixels();
        ClearPixels();

        material.mainTexture = fogOfWarTexture;

        revealers = new List<FogOfWar_Revealer>();

        pixelsPerUnit = Mathf.RoundToInt(textureSize / transform.lossyScale.x);

        centerPixel = new Vector2(textureSize * .5f, textureSize * .5f);
    }

    public void RegisterRevealer(FogOfWar_Revealer revealer)
    {
        revealers.Add(revealer);
    }

    private void ClearPixels()
    {
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = fogOfWarColor;
        }
    }

    private void CreateCircle(int originX, int originY, int radius)
    {
        int scale = pixelsPerUnit * radius;

        for (int y = -scale; y <= scale; y++)
        {
            for (int x = -scale; x <= scale; x++)
            {
                if (x * x + y * y <= scale * scale)
                {
                    pixels[(originY + y) * textureSize + originX + x] = new Color(0, 0, 0, 0);
                }
            }
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ClearPixels();

        for (int i = 0; i < revealers.Count; i++)
        {
            FogOfWar_Revealer revealer = revealers[i];

            Vector3 screenPoint = Camera.main.WorldToScreenPoint(revealer.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(screenPoint);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 1000.0f, fogOfWarLayer.value))
            {
                Vector3 translatedPosition = hitInfo.point - transform.position;

                int pixelX = Mathf.RoundToInt(translatedPosition.x * pixelsPerUnit + centerPixel.x);
                int pixelY = Mathf.RoundToInt(translatedPosition.z * pixelsPerUnit + centerPixel.y);

                CreateCircle(pixelX, pixelY, revealer.RevealedDistance);
            }
        }

        fogOfWarTexture.SetPixels(pixels);
        fogOfWarTexture.Apply(false);
    }
}
