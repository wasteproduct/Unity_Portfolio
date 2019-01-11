using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileDataSet;
using MapDataSet;

[CreateAssetMenu(fileName = "", menuName = "Manager/Current Screen Tiles", order = 1)]
public class Manager_CurrentScreenTiles : ScriptableObject
{
    [SerializeField]
    private int tilesRange;

    public List<Map_TileData> Tiles { get; private set; }

    public void UpdateScreenTiles(Map_Data mapData, int currentX, int currentZ)
    {
        Tiles = new List<Map_TileData>();

        int radius = tilesRange / 2;
        int minimumZ = currentZ - radius;
        int maximumZ = currentZ + radius;
        int minimumX = currentX - radius;
        int maximumX = currentX + radius;

        for (int z = minimumZ; z <= maximumZ; z++)
        {
            if ((z < 0) || (z >= 128)) continue;

            for (int x = minimumX; x <= maximumX; x++)
            {
                if ((x < 0) || (x >= 128)) continue;

                Tiles.Add(mapData.TileData[x, z]);
            }
        }
    }
}
