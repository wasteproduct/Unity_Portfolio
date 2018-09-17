using System.Collections.Generic;
using UnityEngine;
using TileDataSet;
using RoomDataSet;

namespace MapDataSet
{
    public enum MapSize
    {
        Easy,
        Normal,
        Hard
    }

    public class MapArea
    {
        public MapArea(int x, int z)
        {
            X = x;
            Z = z;
        }

        public int X { get; private set; }
        public int Z { get; private set; }
    }

    public class Map_Data
    {
        private readonly int invalidIndex;

        public Map_Data(MapSize mapSize, Manager_CommonFeatures commonFeatures, EnemyZonesData enemyZonesData)
        {
            invalidIndex = commonFeatures.invalidIndex;

            int areaTiles = 32;
            int areasRow = invalidIndex;
            int areasColumn = invalidIndex;

            switch (mapSize)
            {
                case MapSize.Easy:
                    areasRow = 2;
                    areasColumn = 2;
                    break;
                case MapSize.Normal:
                    areasRow = 3;
                    areasColumn = 3;
                    break;
                case MapSize.Hard:
                    areasRow = 4;
                    areasColumn = 4;
                    break;
            }

            List<MapArea> mapAreas = SetAreas(mapSize, areasRow, areasColumn, areaTiles);

            SetTileData(areasRow, areasColumn, areaTiles);

            List<Room> rooms = CreateRooms(mapAreas);

            SetRooms(rooms);

            SetDoors(mapAreas, rooms);

            ConnectRooms(rooms);

            SetWalls();

            StartingTile = TileData[rooms[0].CenterX, rooms[0].CenterZ];

            SetEnemyZones(rooms, enemyZonesData);
        }

        public int TilesRow { get; private set; }
        public int TilesColumn { get; private set; }
        public Map_TileData[,] TileData { get; private set; }
        public List<Map_TileData> Doors { get; private set; }
        public Map_TileData StartingTile { get; private set; }

        private void SetEnemyZones(List<Room> rooms, EnemyZonesData enemyZonesData)
        {
            for (int i = 1; i < rooms.Count; i++)
            {
                Map_TileData center = TileData[rooms[i].CenterX, rooms[i].CenterZ];
                Map_TileData left = TileData[rooms[i].CenterX - 1, rooms[i].CenterZ];
                Map_TileData right = TileData[rooms[i].CenterX + 1, rooms[i].CenterZ];
                Map_TileData upper = TileData[rooms[i].CenterX, rooms[i].CenterZ + 1];
                Map_TileData lower = TileData[rooms[i].CenterX, rooms[i].CenterZ - 1];

                enemyZonesData.AddNewZone(center, left, right, upper, lower);
            }
        }

        private void SetWalls()
        {
            for (int z = 0; z < TilesColumn; z++)
            {
                for (int x = 0; x < TilesRow; x++)
                {
                    if ((TileData[x, z].Type == TileType.Floor) || (TileData[x, z].Type == TileType.Door)) continue;

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

            for (int i = 0; i < Doors.Count; i++)
            {
                switch (Doors[i].Walls[0])
                {
                    case WallDirection.Left:
                        TileData[Doors[i].X, Doors[i].Z - 1].Type = TileType.DoorWall;
                        TileData[Doors[i].X, Doors[i].Z + 1].Type = TileType.DoorWall;
                        break;
                    case WallDirection.Right:
                        TileData[Doors[i].X, Doors[i].Z + 1].Type = TileType.DoorWall;
                        TileData[Doors[i].X, Doors[i].Z - 1].Type = TileType.DoorWall;
                        break;
                    case WallDirection.Near:
                        TileData[Doors[i].X + 1, Doors[i].Z].Type = TileType.DoorWall;
                        TileData[Doors[i].X - 1, Doors[i].Z].Type = TileType.DoorWall;
                        break;
                    case WallDirection.Far:
                        TileData[Doors[i].X - 1, Doors[i].Z].Type = TileType.DoorWall;
                        TileData[Doors[i].X + 1, Doors[i].Z].Type = TileType.DoorWall;
                        break;
                }
            }
        }

        private bool RowIndexAvailable(int x)
        {
            if ((x < 0) || (x >= TilesRow)) return false;

            return true;
        }

        private bool ColumnIndexAvailable(int z)
        {
            if ((z < 0) || (z >= TilesColumn)) return false;

            return true;
        }

        private void ConnectRooms(List<Room> rooms)
        {
            for (int i = 0; i < rooms.Count - 1; i++)
            {
                int nextRoom = i + 1;

                int x = rooms[i].CenterX;
                int z = rooms[i].CenterZ;

                int xIncrementor = (x < rooms[nextRoom].CenterX) ? 1 : -1;
                int zIncrementor = (z < rooms[nextRoom].CenterZ) ? 1 : -1;

                while (true)
                {
                    if (x == rooms[nextRoom].CenterX) break;

                    x += xIncrementor;

                    if (TileData[x, z].Type == TileType.Floor) continue;

                    int upperZ = z + 1;
                    if (upperZ < TilesColumn) TileData[x, upperZ].Type = TileType.Floor;

                    int lowerZ = z - 1;
                    if (lowerZ >= 0) TileData[x, lowerZ].Type = TileType.Floor;

                    if (TileData[x, z].Type == TileType.Door) continue;
                    TileData[x, z].Type = TileType.Floor;
                }

                while (true)
                {
                    if (z == rooms[nextRoom].CenterZ) break;

                    z += zIncrementor;

                    if (TileData[x, z].Type == TileType.Floor) continue;

                    int leftX = x - 1;
                    if (leftX >= 0) TileData[leftX, z].Type = TileType.Floor;

                    int rightX = x + 1;
                    if (rightX < TilesRow) TileData[rightX, z].Type = TileType.Floor;

                    if (TileData[x, z].Type == TileType.Door) continue;
                    TileData[x, z].Type = TileType.Floor;
                }
            }
        }

        private void SetDoors(List<MapArea> mapAreas, List<Room> rooms)
        {
            Doors = new List<Map_TileData>();

            for (int i = 0; i < rooms.Count; i++)
            {
                SetDoorToPreviousRoom(i - 1, i, mapAreas, rooms);
                SetDoorToNextRoom(i, i + 1, mapAreas, rooms);
            }
        }

        private void SetDoorToNextRoom(int currentIndex, int nextIndex, List<MapArea> mapAreas, List<Room> rooms)
        {
            if (nextIndex >= mapAreas.Count) return;

            const int horizontal = -1;
            const int vertical = 1;

            int direction = 0;
            direction = (mapAreas[currentIndex].Z == mapAreas[nextIndex].Z) ? horizontal : vertical;

            int doorX = invalidIndex;
            int doorZ = invalidIndex;
            WallDirection doorDirection = WallDirection.None;

            switch (direction)
            {
                case horizontal:
                    doorDirection = (mapAreas[currentIndex].X < mapAreas[nextIndex].X) ? WallDirection.Right : WallDirection.Left;
                    break;
                case vertical:
                    doorDirection = WallDirection.Far;
                    break;
                default:
                    Debug.Log("Direction was decided unsuccessfully.");
                    return;
            }

            switch (doorDirection)
            {
                case WallDirection.Left:
                    doorX = rooms[currentIndex].X - 1;
                    doorZ = rooms[currentIndex].CenterZ;
                    break;
                case WallDirection.Right:
                    doorX = rooms[currentIndex].Right + 1;
                    doorZ = rooms[currentIndex].CenterZ;
                    break;
                case WallDirection.Far:
                    doorX = rooms[nextIndex].CenterX;
                    doorZ = rooms[currentIndex].Top + 1;
                    break;
            }

            if ((doorX == invalidIndex) || (doorZ == invalidIndex))
            {
                Debug.Log("Door indices were set unsuccessfully.");
                return;
            }

            TileData[doorX, doorZ].Type = TileType.Door;
            TileData[doorX, doorZ].SetWallDirection(doorDirection);
            Doors.Add(TileData[doorX, doorZ]);
        }

        private void SetDoorToPreviousRoom(int previousIndex, int currentIndex, List<MapArea> mapAreas, List<Room> rooms)
        {
            if (previousIndex < 0) return;

            const int horizontal = -1;
            const int vertical = 1;

            int direction = 0;
            direction = (mapAreas[previousIndex].Z == mapAreas[currentIndex].Z) ? horizontal : vertical;

            int doorX = invalidIndex;
            int doorZ = invalidIndex;
            WallDirection doorDirection = WallDirection.None;

            switch (direction)
            {
                case horizontal:
                    doorDirection = (mapAreas[previousIndex].X < mapAreas[currentIndex].X) ? WallDirection.Left : WallDirection.Right;
                    break;
                case vertical:
                    doorDirection = WallDirection.Near;
                    break;
                default:
                    Debug.Log("Direction was decided unsuccessfully.");
                    return;
            }

            switch (doorDirection)
            {
                case WallDirection.Left:
                    doorX = rooms[currentIndex].X - 1;
                    doorZ = rooms[previousIndex].CenterZ;
                    break;
                case WallDirection.Right:
                    doorX = rooms[currentIndex].Right + 1;
                    doorZ = rooms[previousIndex].CenterZ;
                    break;
                case WallDirection.Near:
                    doorX = rooms[currentIndex].CenterX;
                    doorZ = rooms[currentIndex].Z - 1;
                    break;
            }

            if ((doorX == invalidIndex) || (doorZ == invalidIndex))
            {
                Debug.Log("Door indices were set unsuccessfully.");
                return;
            }

            TileData[doorX, doorZ].Type = TileType.Door;
            TileData[doorX, doorZ].SetWallDirection(doorDirection);
            Doors.Add(TileData[doorX, doorZ]);
        }

        private void SetRooms(List<Room> rooms)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                for (int z = rooms[i].Z; z <= rooms[i].Top; z++)
                {
                    for (int x = rooms[i].X; x <= rooms[i].Right; x++)
                    {
                        TileData[x, z].Type = TileType.Floor;
                    }
                }
            }
        }

        private List<Room> CreateRooms(List<MapArea> mapAreas)
        {
            List<Room> result = new List<Room>();

            for (int i = 0; i < mapAreas.Count; i++)
            {
                int x = Random.Range(mapAreas[i].X + 3, mapAreas[i].X + 8);
                int z = Random.Range(mapAreas[i].Z + 3, mapAreas[i].Z + 8);
                int roomWidth = Random.Range(16, 26);
                int roomHeight = Random.Range(16, 26);

                Room newRoom = new Room(x, z, roomWidth, roomHeight);

                result.Add(newRoom);
            }

            return result;
        }

        private void SetTileData(int areasRow, int areasColumn, int areaTiles)
        {
            TilesRow = areaTiles * areasRow;
            TilesColumn = areaTiles * areasColumn;

            TileData = new Map_TileData[TilesRow, TilesColumn];

            for (int z = 0; z < TilesColumn; z++)
            {
                for (int x = 0; x < TilesRow; x++)
                {
                    TileData[x, z] = new Map_TileData(x, z);
                }
            }
        }

        private List<MapArea> SetAreas(MapSize mapSize, int areasRow, int areasColumn, int areaTiles)
        {
            List<MapArea> result = new List<MapArea>();

            for (int z = 0; z < areasColumn; z++)
            {
                for (int x = 0; x < areasRow; x++)
                {
                    int areaX = (z % 2 == 0) ? x * areaTiles : (areasRow - 1 - x) * areaTiles;
                    int areaZ = z * areaTiles;

                    MapArea newArea = new MapArea(areaX, areaZ);

                    result.Add(newArea);
                }
            }

            return result;
        }
    }
}
