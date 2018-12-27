using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class MapArea
    {
        private const int vertical = 0;
        private const int horizontal = 1;
        private const int areaSize = 32;

        public MapArea(int startX, int startZ, int endX, int endZ, int loopCount)
        {
            StartX = startX;
            StartZ = startZ;
            EndX = endX;
            EndZ = endZ;

            Children = null;

            if (loopCount > 3) return;

            Children = new MapArea[2];

            int dividingDirection = ((EndZ - StartZ) > (EndX - StartX)) ? horizontal : vertical;

            switch (dividingDirection)
            {
                case vertical:
                    int dividingX = Random.Range(StartX + areaSize, EndX - areaSize);

                    Children[0] = new MapArea(StartX, StartZ, dividingX, EndZ, loopCount + 1);
                    Children[1] = new MapArea(dividingX + 1, StartZ, EndX, EndZ, loopCount + 1);
                    break;
                case horizontal:
                    int dividingZ = Random.Range(StartZ + areaSize, EndZ - areaSize);

                    Children[0] = new MapArea(StartX, StartZ, EndX, dividingZ, loopCount + 1);
                    Children[1] = new MapArea(StartX, dividingZ + 1, EndX, EndZ, loopCount + 1);
                    break;
            }
        }

        public int StartX { get; private set; }
        public int StartZ { get; private set; }
        public int EndX { get; private set; }
        public int EndZ { get; private set; }
        public MapArea[] Children { get; private set; }
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
            MapArea mapArea = new MapArea(0, 0, 128, 128, 0);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
