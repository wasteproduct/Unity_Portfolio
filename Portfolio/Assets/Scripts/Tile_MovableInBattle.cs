using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileDataSet
{
    public class Tile_MovableInBattle : MonoBehaviour
    {
        public Map_TileData TileData { get; private set; }

        public void SetData(Map_TileData tileData)
        {
            TileData = tileData;
        }
    }
}
