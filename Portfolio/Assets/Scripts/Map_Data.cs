using System.Collections.Generic;
using UnityEngine;
using TileDataSet;

namespace MapDataSet
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

    public class Map_Data
    {
        private readonly int invalidIndex;

        public Map_Data(Manager_CommonFeatures commonFeatures, EnemyZonesData enemyZonesData)
        {
            invalidIndex = commonFeatures.invalidIndex;

            MapLength = 128;

            LeafAreas = new List<MapArea>();
            TotalAreas = new List<MapArea>();

            MapArea entireArea = new MapArea(0, 0, MapLength, MapLength, 0, LeafAreas, TotalAreas, null);

            Rooms = new List<Room>();

            SetTileData();

            for (int i = 0; i < LeafAreas.Count; i++)
            {
                Rooms.Add(new Room(LeafAreas[i]));
            }

            SetRooms();

            ConnectRooms();

            SetWalls();

            StartingTile = TileData[LeafAreas[0].CenterX, LeafAreas[0].CenterZ];

            SetEnemyZones(enemyZonesData);
        }

        public int MapLength { get; private set; }
        public Map_TileData[,] TileData { get; private set; }
        public Map_TileData StartingTile { get; private set; }

        public List<MapArea> LeafAreas { get; private set; }
        public List<MapArea> TotalAreas { get; private set; }
        public List<Room> Rooms { get; private set; }

        private void SetEnemyZones(EnemyZonesData enemyZonesData)
        {
            for (int i = 1; i < Rooms.Count; i++)
            {
                Map_TileData center = TileData[Rooms[i].LocatedArea.CenterX, Rooms[i].LocatedArea.CenterZ];
                Map_TileData left = TileData[Rooms[i].LocatedArea.CenterX - 1, Rooms[i].LocatedArea.CenterZ];
                Map_TileData right = TileData[Rooms[i].LocatedArea.CenterX + 1, Rooms[i].LocatedArea.CenterZ];
                Map_TileData upper = TileData[Rooms[i].LocatedArea.CenterX, Rooms[i].LocatedArea.CenterZ + 1];
                Map_TileData lower = TileData[Rooms[i].LocatedArea.CenterX, Rooms[i].LocatedArea.CenterZ - 1];

                enemyZonesData.AddNewZone(center, left, right, upper, lower);
            }
        }

        private void SetWalls()
        {
            for (int z = 0; z < MapLength; z++)
            {
                for (int x = 0; x < MapLength; x++)
                {
                    if ((TileData[x, z].Type == TileType.Floor) || (TileData[x, z].Type == TileType.Door) || (TileData[x, z].Type == TileType.DoorWall)) continue;

                    int upper = z + 1;
                    int lower = z - 1;
                    int left = x - 1;
                    int right = x + 1;

                    if (ColumnIndexAvailable(upper) == true)
                    {
                        if (TileData[x, upper].Type == TileType.Floor)
                        {
                            TileData[x, z].Type = TileType.Wall;
                            TileData[x, z].SetWallDirection(x, z, x, upper);
                        }
                    }

                    if (ColumnIndexAvailable(lower) == true)
                    {
                        if (TileData[x, lower].Type == TileType.Floor)
                        {
                            TileData[x, z].Type = TileType.Wall;
                            TileData[x, z].SetWallDirection(x, z, x, lower);
                        }
                    }

                    if (RowIndexAvailable(left) == true)
                    {
                        if (TileData[left, z].Type == TileType.Floor)
                        {
                            TileData[x, z].Type = TileType.Wall;
                            TileData[x, z].SetWallDirection(x, z, left, z);
                        }
                    }

                    if (RowIndexAvailable(right) == true)
                    {
                        if (TileData[right, z].Type == TileType.Floor)
                        {
                            TileData[x, z].Type = TileType.Wall;
                            TileData[x, z].SetWallDirection(x, z, right, z);
                        }
                    }
                }
            }
        }

        private bool RowIndexAvailable(int x)
        {
            if ((x < 0) || (x >= MapLength)) return false;

            return true;
        }

        private bool ColumnIndexAvailable(int z)
        {
            if ((z < 0) || (z >= MapLength)) return false;

            return true;
        }

        private void ConnectRooms()
        {
            for (int i = 0; i < TotalAreas.Count; i++)
            {
                MapArea currentArea = TotalAreas[i];

                if (currentArea.SisterArea == null) continue;

                switch (currentArea.SisterDirection)
                {
                    case AreaDirection.Vertical:
                        for (int z = currentArea.SisterArea.CenterZ; z < currentArea.CenterZ; z++)
                        {
                            TileData[currentArea.CenterX - 1, z].Type = TileType.Floor;
                            TileData[currentArea.CenterX, z].Type = TileType.Floor;
                            TileData[currentArea.CenterX + 1, z].Type = TileType.Floor;
                        }
                        break;
                    case AreaDirection.Horizontal:
                        for (int x = currentArea.SisterArea.CenterX; x < currentArea.CenterX; x++)
                        {
                            TileData[x, currentArea.CenterZ - 1].Type = TileType.Floor;
                            TileData[x, currentArea.CenterZ].Type = TileType.Floor;
                            TileData[x, currentArea.CenterZ + 1].Type = TileType.Floor;
                        }
                        break;
                }
            }
        }

        private void SetRooms()
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                Room currentRoom = Rooms[i];

                for (int z = currentRoom.StartZ; z < currentRoom.EndZ; z++)
                {
                    for (int x = currentRoom.StartX; x < currentRoom.EndX; x++)
                    {
                        TileData[x, z].Type = TileType.Floor;
                    }
                }
            }
        }

        private void SetTileData()
        {
            TileData = new Map_TileData[MapLength, MapLength];

            for (int z = 0; z < MapLength; z++)
            {
                for (int x = 0; x < MapLength; x++)
                {
                    TileData[x, z] = new Map_TileData(x, z);
                }
            }
        }
    }
}
