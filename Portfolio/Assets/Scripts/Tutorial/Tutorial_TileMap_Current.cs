using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_TileMap_Current : MonoBehaviour
    {
        public Tutorial_TileMap CurrentMap { get; private set; }

        public void SetCurrentMap(Tutorial_TileMap tileMap) { CurrentMap = tileMap; }

        public void DiscardMap()
        {
            GetComponent<MeshCollider>().sharedMesh = null;
            GetComponent<MeshRenderer>().materials = new Material[0];
            GetComponent<MeshFilter>().mesh = null;
        }
    }
}
