using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshCollider))]
    [RequireComponent(typeof(MeshRenderer))]
    public class Tutorial_TileMap_2 : Tutorial_TileMap
    {
        public void GenerateMap()
        {
            SetTiles();

            SetFloors();

            InstantiateTiles();

            CombineFloors();
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
    }
}
