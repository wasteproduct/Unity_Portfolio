using System.Collections.Generic;
using UnityEngine;
using MapDataSet;

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
    public Map_Data MapData { get; private set; }
    
    public void RevealArea(Map_EnemyZone enemyZone)
    {
        int areaLeft = enemyZone.ZoneData.left;
        int areaRight = enemyZone.ZoneData.right;
        int areaBottom = enemyZone.ZoneData.bottom;
        int areaTop = enemyZone.ZoneData.top;

        for (int z = areaBottom; z <= areaTop; z++)
        {
            for (int x = areaLeft; x <= areaRight; x++)
            {
                if (MapData.TileData[x, z].Revealed == true) continue;

                Ray ray = Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(new Vector3(x, 0, z)));
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, 1000.0f, fogOfWarLayer.value))
                {
                    Vector3 translatedPosition = hitInfo.point - transform.position;

                    int pixelX = Mathf.RoundToInt(translatedPosition.x * pixelsPerUnit + centerPixel.x);
                    int pixelY = Mathf.RoundToInt(translatedPosition.z * pixelsPerUnit + centerPixel.y);

                    RevealTile(pixelX, pixelY);

                    MapData.TileData[x, z].Revealed = true;
                }
            }
        }

        fogOfWarTexture.SetPixels(pixels);
        fogOfWarTexture.Apply(false);
    }
    
    public void RevealArea()
    {
        int revealedDistance = revealers[0].RevealedDistance;

        for (int z = currentTileZ.value - revealedDistance; z <= currentTileZ.value + revealedDistance; z++)
        {
            if ((z < 0) || (z >= tilesColumn)) continue;

            for (int x = currentTileX.value - revealedDistance; x <= currentTileX.value + revealedDistance; x++)
            {
                if ((x < 0) || (x >= tilesRow)) continue;

                if (MapData.TileData[x, z].Revealed == true) continue;
                
                Ray ray = Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(new Vector3(x, 0, z)));
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, 1000.0f, fogOfWarLayer.value))
                {
                    Vector3 translatedPosition = hitInfo.point - transform.position;

                    int pixelX = Mathf.RoundToInt(translatedPosition.x * pixelsPerUnit + centerPixel.x);
                    int pixelY = Mathf.RoundToInt(translatedPosition.z * pixelsPerUnit + centerPixel.y);

                    RevealTile(pixelX, pixelY);

                    MapData.TileData[x, z].Revealed = true;
                }
            }
        }

        fogOfWarTexture.SetPixels(pixels);
        fogOfWarTexture.Apply(false);
    }

    public void Initialize(Map_Data mapData)
    {
        MapData = mapData;
        //tilesRow = MapData.TilesRow;
        //tilesColumn = MapData.TilesColumn;
        tilesRow = MapData.MapLength;
        tilesColumn = MapData.MapLength;

        transform.position = new Vector3(tilesRow / 2, 5.0f, tilesColumn / 2);
        transform.localScale *= tilesColumn * 1.28f;

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

    private void Awake()
    {
        Instance = this;
    }

    private void RevealTile(int originX, int originY)
    {
        int halfUnit = pixelsPerUnit / 2;

        for (int y = -halfUnit; y <= halfUnit; y++)
        {
            for (int x = -halfUnit; x <= halfUnit; x++)
            {
                pixels[(originY + y) * textureSize + originX + x] = new Color(0, 0, 0, 0);
            }
        }
    }

    private void ClearPixels()
    {
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = fogOfWarColor;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
