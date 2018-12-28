using System.Collections.Generic;
using MapObject;

namespace TileDataSet
{
    public enum TileType
    {
        None,
        Floor,
        Door,
        DoorWall,
        Wall,
        Interactor
    }

    public enum WallDirection
    {
        None,
        Left,
        Right,
        Near,
        Far
    }

    public class Map_TileData
    {
        public Map_TileData(int x, int z)
        {
            X = x;
            Z = z;

            Type = TileType.None;

            Walls = new List<WallDirection>();

            Revealed = false;
        }

        public int X { get; private set; }
        public int Z { get; private set; }
        public TileType Type { get; set; }
        public List<WallDirection> Walls { get; private set; }
        public bool Revealed { get; set; }

        public Object_Door Door { get; set; }
        public Object_InteractorBase Interactor { get; set; }

        public void React()
        {
            Interactor.Interact();
        }

        public void OpenDoor()
        {
            Type = TileType.Floor;
            Door.Open();
        }

        public void SetWallDirection(WallDirection wallDirection)
        {
            Walls.Add(wallDirection);
        }

        public void SetWallDirection(int wallX, int wallZ, int adjacentFloorX, int adjacentFloorZ)
        {
            int x = adjacentFloorX - wallX;
            int z = adjacentFloorZ - wallZ;

            WallDirection wallDirection = WallDirection.None;

            if (z == 0) wallDirection = (x > 0) ? WallDirection.Left : WallDirection.Right;
            else wallDirection = (z > 0) ? WallDirection.Near : WallDirection.Far;

            Walls.Add(wallDirection);
        }
    }
}
