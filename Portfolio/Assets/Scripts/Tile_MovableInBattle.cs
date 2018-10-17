using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileDataSet
{
    public class Tile_MovableInBattle : MonoBehaviour
    {
        public Material normal;
        public Material attack;

        public Map_TileData TileData { get; private set; }

        public void SetDetails(Map_TileData tileData, bool targetInRange)
        {
            TileData = tileData;
            this.GetComponent<MeshRenderer>().material = normal;

            if (targetInRange == true) this.GetComponent<MeshRenderer>().material = attack;
        }
    }
}
