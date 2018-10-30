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
        public Battle_TurnController turnController;

        private Map_Data mapData;

        public List<GameObject> MovableTiles { get; private set; }
        public GameObject DestinationTile { get; private set; }

        public void SetDestinationTile(Map_TileData destinationTile)
        {
            for (int i = 0; i < MovableTiles.Count; i++)
            {
                Map_TileData tileData = MovableTiles[i].GetComponent<Tile_MovableInBattle>().TileData;

                if (tileData == destinationTile)
                {
                    DestinationTile = MovableTiles[i];
                    Debug.Log("Destination fixed.");
                    return;
                }
            }
        }

        public void SetDestinationTile(GameObject destinationTile)
        {
            DestinationTile = null;
            DestinationTile = destinationTile;
        }

        public bool OutOfMovableRange(Map_TileData destinationTile)
        {
            for (int i = 0; i < MovableTiles.Count; i++)
            {
                if (MovableTiles[i].GetComponent<Tile_MovableInBattle>().TileData == destinationTile) return false;
            }

            return true;
        }

        public void Initialize(Map_Data MapData)
        {
            mapData = MapData;

            MovableTiles = new List<GameObject>();
        }

        public void SetTiles()
        {
            ClearTilesList();

            int standingX = turnController.CurrentTurnCharacter.StandingTileX;
            int standingZ = turnController.CurrentTurnCharacter.StandingTileZ;
            int movableDistance = turnController.CurrentTurnCharacter.MovableDistance;

            for (int z = standingZ - movableDistance; z <= standingZ + movableDistance; z++)
            {
                for (int x = standingX - movableDistance; x <= standingX + movableDistance; x++)
                {
                    if ((Mathf.Abs(z - standingZ) + Mathf.Abs(x - standingX)) > movableDistance) continue;

                    if (mapData.TileData[x, z].Type != TileType.Floor) continue;

                    if (TileOccupied(x, z) == true) continue;

                    Vector3 newTilePosition = new Vector3((float)mapData.TileData[x, z].X, 0.0f, (float)mapData.TileData[x, z].Z);
                    GameObject newTile = Instantiate(tilePrefab, newTilePosition, Quaternion.identity);

                    newTile.GetComponent<Tile_MovableInBattle>().SetDetails(mapData.TileData[x, z]);

                    MovableTiles.Add(newTile);
                }
            }
        }

        private bool TileOccupied(int x, int z)
        {
            List<Character_InBattle> playerCharacters = turnController.PlayerCharacters;
            List<Character_InBattle> enemyCharacters = turnController.EnemyCharacters;
            Character_InBattle currentTurnCharacter = turnController.CurrentTurnCharacter;

            for (int i = 0; i < playerCharacters.Count; i++)
            {
                if (currentTurnCharacter == playerCharacters[i]) continue;

                if ((x == playerCharacters[i].StandingTileX) && (z == playerCharacters[i].StandingTileZ)) return true;
            }

            for (int i = 0; i < enemyCharacters.Count; i++)
            {
                if (currentTurnCharacter == enemyCharacters[i]) continue;

                if ((x == enemyCharacters[i].StandingTileX) && (z == enemyCharacters[i].StandingTileZ)) return true;
            }

            return false;
        }

        private void ClearTilesList()
        {
            for (int i = MovableTiles.Count - 1; i >= 0; i--)
            {
                Destroy(MovableTiles[i].gameObject);

                MovableTiles.RemoveAt(i);
            }

            MovableTiles.Clear();
        }
    }
}
