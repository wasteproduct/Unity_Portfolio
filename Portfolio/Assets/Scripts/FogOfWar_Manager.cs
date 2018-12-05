using System.Collections;
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

    private Texture2D fogOfWarTexture;
    private Color[] pixels;
    private List<FogOfWar_Revealer> revealers;
    private int pixelsPerUnit;
    private Vector2 centerPixel;

    public static FogOfWar_Manager Instance { get; private set; }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
