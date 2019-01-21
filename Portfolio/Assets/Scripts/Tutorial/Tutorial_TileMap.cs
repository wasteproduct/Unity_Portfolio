using UnityEngine;

namespace Tutorial
{
    public abstract class Tutorial_TileMap : MonoBehaviour
    {
        public class Tutorial_Tile
        {
            public enum TileType
            {
                None,
                Floor
            }

            public Tutorial_Tile(int x, int z, TileType type = TileType.None)
            {
                X = x;
                Z = z;
                Type = type;
            }

            public int X { get; private set; }
            public int Z { get; private set; }
            public TileType Type { get; set; }
        }

        [SerializeField]
        protected int row;
        [SerializeField]
        protected int column;
        [SerializeField]
        protected GameObject tilePrefab;
    }
}
