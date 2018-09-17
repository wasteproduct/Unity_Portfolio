namespace RoomDataSet
{
    public class Room
    {
        private readonly int width, height;

        public Room(int x, int z, int roomWidth, int roomHeight)
        {
            X = x;
            Z = z;

            width = roomWidth;
            height = roomHeight;

            Right = X + width - 1;
            Top = Z + height - 1;

            CenterX = X + width / 2;
            CenterZ = Z + height / 2;
        }

        public int X { get; private set; }
        public int Z { get; private set; }
        public int Right { get; private set; }
        public int Top { get; private set; }
        public int CenterX { get; private set; }
        public int CenterZ { get; private set; }

        public bool RoomsOverlapping(Room room)
        {
            if (this.X > room.Right + 6) return false;
            if (this.Right < room.X - 6) return false;
            if (this.Z > room.Top + 6) return false;
            if (this.Top < room.Z - 6) return false;

            return true;
        }
    }
}
