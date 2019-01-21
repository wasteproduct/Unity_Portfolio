using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_TileMap_Current : MonoBehaviour
    {
        public Tutorial_TileMap CurrentMap { get; private set; }

        public void SetCurrentMap(Tutorial_TileMap tileMap) { CurrentMap = tileMap; }
    }
}
