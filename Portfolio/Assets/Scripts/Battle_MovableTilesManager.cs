using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileDataSet;
using MapDataSet;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Movable Tiles Manager", order = 1)]
    public class Battle_MovableTilesManager : ScriptableObject
    {
        public GameObject tilePrefab;

        private List<GameObject> movableTiles;

        public void Initialize()
        {
            movableTiles = new List<GameObject>();
        }

        public void SetTiles(Map_Data mapData, int standingX, int standingZ)
        {
            ClearTilesList();

            for (int z = standingZ - 3; z <= standingZ + 3; z++)
            {
                for (int x = standingX - 3; x <= standingX + 3; x++)
                {
                    if ((Mathf.Abs(z - standingZ) + Mathf.Abs(x - standingX)) > 3) continue;

                    if (mapData.TileData[x, z].Type != TileType.Floor) continue;

                    Vector3 newTilePosition = new Vector3((float)mapData.TileData[x, z].X, 0.0f, (float)mapData.TileData[x, z].Z);
                    GameObject newTile = Instantiate<GameObject>(tilePrefab, newTilePosition, Quaternion.identity);
                    newTile.GetComponent<Tile_MovableInBattle>().SetData(mapData.TileData[x, z]);

                    movableTiles.Add(newTile);
                }
            }
        }

        private void ClearTilesList()
        {
            for (int i = movableTiles.Count - 1; i >= 0; i--)
            {
                Destroy(movableTiles[i].gameObject);

                movableTiles.RemoveAt(i);
            }

            movableTiles.Clear();
        }
    }
}
