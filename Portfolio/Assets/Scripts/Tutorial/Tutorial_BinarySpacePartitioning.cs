using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public enum AreaDirection
    {
        Vertical,
        Horizontal
    }

    public class MapArea
    {
        private const int areaSize = 32;

        public MapArea(int startX, int startZ, int endX, int endZ, int loopCount, List<MapArea> leafAreas, List<MapArea> totalAreas, MapArea sisterArea)
        {
            StartX = startX;
            StartZ = startZ;
            EndX = endX;
            EndZ = endZ;
            CenterX = StartX + (EndX - StartX) / 2;
            CenterZ = StartZ + (EndZ - StartZ) / 2;

            SisterArea = sisterArea;
            if (SisterArea != null) SisterDirection = (CenterZ == SisterArea.CenterZ) ? AreaDirection.Horizontal : AreaDirection.Vertical;

            if (loopCount > 2)
            {
                leafAreas.Add(this);
                totalAreas.Add(this);
                return;
            }

            MapArea[] children = new MapArea[2];

            AreaDirection dividingDirection = ((EndZ - StartZ) > (EndX - StartX)) ? AreaDirection.Horizontal : AreaDirection.Vertical;

            switch (dividingDirection)
            {
                case AreaDirection.Vertical:
                    int dividingX = Random.Range(StartX + areaSize, EndX - areaSize);

                    children[0] = new MapArea(StartX, StartZ, dividingX, EndZ, loopCount + 1, leafAreas, totalAreas, null);
                    children[1] = new MapArea(dividingX, StartZ, EndX, EndZ, loopCount + 1, leafAreas, totalAreas, children[0]);
                    break;
                case AreaDirection.Horizontal:
                    int dividingZ = Random.Range(StartZ + areaSize, EndZ - areaSize);

                    children[0] = new MapArea(StartX, StartZ, EndX, dividingZ, loopCount + 1, leafAreas, totalAreas, null);
                    children[1] = new MapArea(StartX, dividingZ, EndX, EndZ, loopCount + 1, leafAreas, totalAreas, children[0]);
                    break;
            }

            if (loopCount < 1) return;

            totalAreas.Add(this);
        }

        public int StartX { get; private set; }
        public int StartZ { get; private set; }
        public int EndX { get; private set; }
        public int EndZ { get; private set; }
        public int CenterX { get; private set; }
        public int CenterZ { get; private set; }
        public MapArea SisterArea { get; private set; }
        public AreaDirection SisterDirection { get; private set; }
    }

    public class Room
    {
        public Room(MapArea locatedArea)
        {
            LocatedArea = locatedArea;

            //StartX = Random.Range(LocatedArea.StartX + 3, LocatedArea.StartX + 6);
            //StartZ = Random.Range(LocatedArea.StartZ + 3, LocatedArea.StartZ + 6);
            //EndX = Random.Range(LocatedArea.EndX - 6, LocatedArea.EndX - 3);
            //EndZ = Random.Range(LocatedArea.EndZ - 6, LocatedArea.EndZ - 3);
            StartX = LocatedArea.StartX + 4;
            StartZ = LocatedArea.StartZ + 4;
            EndX = LocatedArea.EndX - 4;
            EndZ = LocatedArea.EndZ - 4;
        }

        public MapArea LocatedArea { get; private set; }
        public int StartX { get; private set; }
        public int StartZ { get; private set; }
        public int EndX { get; private set; }
        public int EndZ { get; private set; }
    }

    public class Tutorial_BinarySpacePartitioning : MonoBehaviour
    {
        public List<MapArea> LeafAreas { get; private set; }
        public List<MapArea> TotalAreas { get; private set; }
        public List<Room> Rooms { get; private set; }

        [SerializeField]
        private GameObject tilePrefab;

        private const int vertical = 0;
        private const int horizontal = 1;
        private const int areaSize = 32;

        // Use this for initialization
        void Start()
        {
            const int mapLength = 128;

            LeafAreas = new List<MapArea>();
            TotalAreas = new List<MapArea>();

            MapArea entireArea = new MapArea(0, 0, mapLength, mapLength, 0, LeafAreas, TotalAreas, null);

            Rooms = new List<Room>();

            //for (int i = 0; i < LeafAreas.Count; i++)
            //{
            //    MapArea currentArea = LeafAreas[i];

            //    for (int z = currentArea.StartZ; z < currentArea.EndZ; z++)
            //    {
            //        Instantiate(tilePrefab, new Vector3(currentArea.StartX, 0, z), Quaternion.identity);
            //        Instantiate(tilePrefab, new Vector3(currentArea.EndX, 0, z), Quaternion.identity);
            //    }

            //    for (int x = currentArea.StartX; x < currentArea.EndX; x++)
            //    {
            //        Instantiate(tilePrefab, new Vector3(x, 0, currentArea.StartZ), Quaternion.identity);
            //        Instantiate(tilePrefab, new Vector3(x, 0, currentArea.EndZ), Quaternion.identity);
            //    }
            //}

            for (int i = 0; i < TotalAreas.Count; i++)
            {
                MapArea currentArea = TotalAreas[i];

                if (currentArea.SisterArea == null) continue;

                switch (currentArea.SisterDirection)
                {
                    case AreaDirection.Vertical:
                        for (int z = currentArea.SisterArea.CenterZ; z < currentArea.CenterZ; z++)
                        {
                            Instantiate(tilePrefab, new Vector3(currentArea.CenterX, 0, z), Quaternion.identity);
                        }
                        break;
                    case AreaDirection.Horizontal:
                        for (int x = currentArea.SisterArea.CenterX; x < currentArea.CenterX; x++)
                        {
                            Instantiate(tilePrefab, new Vector3(x, 0, currentArea.CenterZ), Quaternion.identity);
                        }
                        break;
                }
            }

            for (int i = 0; i < LeafAreas.Count; i++)
            {
                Rooms.Add(new Room(LeafAreas[i]));
            }

            for (int i = 0; i < Rooms.Count; i++)
            {
                Room currentRoom = Rooms[i];

                for (int z = currentRoom.StartZ; z < currentRoom.EndZ; z++)
                {
                    for (int x = currentRoom.StartX; x < currentRoom.EndX; x++)
                    {
                        Instantiate(tilePrefab, new Vector3(x, 0, z), Quaternion.identity);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
