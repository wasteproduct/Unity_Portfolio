using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class MapArea
    {
        public MapArea(int x, int z, int dividedDirection)
        {
            //StartingX = startX;
            //StartingZ = startZ;
            //EndX = endX;
            //EndZ = endZ;
            X = x;
            Z = z;

            DividedDirection = dividedDirection;
        }

        public int X { get; private set; }
        public int Z { get; private set; }
        //public int StartingX { get; private set; }
        //public int StartingZ { get; private set; }
        //public int EndX { get; private set; }
        //public int EndZ { get; private set; }
        public int DividedDirection { get; private set; }
    }

    public class Tutorial_BinarySpacePartitioning : MonoBehaviour
    {
        [SerializeField]
        private GameObject tilePrefab;

        private const int vertical = 0;
        private const int horizontal = 1;
        private const int areaSize = 32;

        // Use this for initialization
        void Start()
        {
            // x 0 - 128, z 0 - 128
            // min x, min z 32





            // horiz / vert random
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
