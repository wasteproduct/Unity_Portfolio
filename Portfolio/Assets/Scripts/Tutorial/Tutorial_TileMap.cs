using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_TileMap : MonoBehaviour
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
        private int row;
        [SerializeField]
        private int column;
        [SerializeField]
        private GameObject tilePrefab;

        public int Row { get { return row; } }
        public int Column { get { return column; } }
        public Tutorial_Tile[,] Tiles { get; private set; }

        public void GenerateMap(int patternNumber)
        {
            DiscardMap();

            SetTiles();

            switch (patternNumber)
            {
                case 1:
                    SetFloors_Pattern1();
                    break;
                case 2:
                    SetFloors_Pattern2();
                    break;
                case 3:
                    SetFloors_Pattern3();
                    break;
                default:
                    SetFloors_Pattern1();
                    return;
            }

            InstantiateTiles();

            CombineFloors();
        }

        public void DiscardMap()
        {
            GetComponent<MeshCollider>().sharedMesh = null;
            GetComponent<MeshRenderer>().materials = new Material[0];
            GetComponent<MeshFilter>().mesh = null;
        }

        private void SetTiles()
        {
            Tiles = new Tutorial_Tile[row, column];

            for (int z = 0; z < column; z++)
            {
                for (int x = 0; x < row; x++)
                {
                    Tiles[x, z] = new Tutorial_Tile(x, z);
                }
            }
        }

        private void CombineFloors()
        {
            Miscellaneous_TilePrefab[] instantiatedTiles = GetComponentsInChildren<Miscellaneous_TilePrefab>(true);

            MeshFilter[] meshFilters = new MeshFilter[instantiatedTiles.Length];

            for (int i = 0; i < instantiatedTiles.Length; i++)
            {
                meshFilters[i] = instantiatedTiles[i].GetComponentInChildren<MeshFilter>();
            }

            CombineInstance[] instances = new CombineInstance[meshFilters.Length];

            List<CombineInstance> floors = new List<CombineInstance>();

            Material floorMaterial = null;

            for (int i = 0; i < meshFilters.Length; i++)
            {
                instances[i] = new CombineInstance();

                instances[i].mesh = meshFilters[i].sharedMesh;
                instances[i].transform = meshFilters[i].transform.localToWorldMatrix;

                floorMaterial = meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial;
                floors.Add(instances[i]);
            }

            Mesh combinedFloor = new Mesh();
            combinedFloor.CombineMeshes(floors.ToArray());

            GetComponent<MeshCollider>().sharedMesh = combinedFloor;

            GetComponent<MeshRenderer>().sharedMaterials = new Material[1];

            GetComponent<MeshRenderer>().sharedMaterial = floorMaterial;

            GetComponent<MeshFilter>().mesh = combinedFloor;

            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }

        private void InstantiateTiles()
        {
            for (int z = 0; z < column; z++)
            {
                for (int x = 0; x < row; x++)
                {
                    if (Tiles[x, z].Type != Tutorial_Tile.TileType.Floor) continue;

                    Vector3 position = new Vector3(Tiles[x, z].X, 0, Tiles[x, z].Z);

                    Instantiate(tilePrefab, position, Quaternion.identity, transform);
                }
            }
        }

        private void SetFloors_Pattern2()
        {
            for (int x = 0; x < row; x++)
            {
                if (x % 2 == 1) continue;

                for (int z = 0; z < column; z++)
                {
                    Tiles[x, z].Type = Tutorial_Tile.TileType.Floor;
                }
            }

            const int top = 0;
            const int bottom = 1;
            int direction = top;

            for (int x = 0; x < row; x++)
            {
                if (x % 2 == 0) continue;

                int z;

                switch (direction)
                {
                    case top:
                        z = column - 1;
                        break;
                    case bottom:
                        z = 0;
                        break;
                    default:
                        print("ERROR");
                        return;
                }

                Tiles[x, z].Type = Tutorial_Tile.TileType.Floor;

                direction++;

                if (direction > bottom) direction = top;
            }
        }

        private void SetFloors_Pattern3()
        {
            const int right = 0;
            const int up = 1;
            const int left = 2;
            const int down = 3;

            int direction = right;

            int leftX = 0;
            int rightX = row - 1;
            int bottomZ = 0;
            int topZ = column - 1;

            bool starting = true;

            while (true)
            {
                switch (direction)
                {
                    case right:
                        for (int x = leftX; x <= rightX; x++)
                        {
                            Tiles[x, bottomZ].Type = Tutorial_Tile.TileType.Floor;
                        }
                        direction++;
                        if (starting == true) starting = false;
                        else leftX += 2;
                        break;
                    case up:
                        for (int z = bottomZ; z <= topZ; z++)
                        {
                            Tiles[rightX, z].Type = Tutorial_Tile.TileType.Floor;
                        }
                        direction++;
                        bottomZ += 2;
                        break;
                    case left:
                        for (int x = rightX; x >= leftX; x--)
                        {
                            Tiles[x, topZ].Type = Tutorial_Tile.TileType.Floor;
                        }
                        direction++;
                        rightX -= 2;
                        break;
                    case down:
                        for (int z = topZ; z >= bottomZ; z--)
                        {
                            Tiles[leftX, z].Type = Tutorial_Tile.TileType.Floor;
                        }
                        direction = right;
                        topZ -= 2;
                        break;
                }

                if ((rightX <= leftX) || (topZ <= bottomZ)) break;
            }
        }

        private void SetFloors_Pattern1()
        {
            for (int z = 0; z < column; z++)
            {
                if (z % 2 == 1) continue;

                for (int x = 0; x < row; x++)
                {
                    Tiles[x, z].Type = Tutorial_Tile.TileType.Floor;
                }
            }

            const int left = 0;
            const int right = 1;
            int direction = right;

            for (int z = 0; z < column; z++)
            {
                if (z % 2 == 0) continue;

                int x;

                switch (direction)
                {
                    case left:
                        x = 0;
                        break;
                    case right:
                        x = row - 1;
                        break;
                    default:
                        print("ERROR");
                        return;
                }

                Tiles[x, z].Type = Tutorial_Tile.TileType.Floor;

                direction++;

                if (direction > right) direction = left;
            }
        }
    }
}
