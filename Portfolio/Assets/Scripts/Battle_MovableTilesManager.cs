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

        public void SetTiles(Character_InBattle currentTurnCharacter, List<Character_InBattle> inBattleCharactersPlayer, List<Character_InBattle> inBattleEnemies)
        {
            ClearTilesList();

            int standingX = currentTurnCharacter.StandingTileX;
            int standingZ = currentTurnCharacter.StandingTileZ;

            for (int z = standingZ - 3; z <= standingZ + 3; z++)
            {
                for (int x = standingX - 3; x <= standingX + 3; x++)
                {
                    if ((Mathf.Abs(z - standingZ) + Mathf.Abs(x - standingX)) > 3) continue;

                    if (mapData.TileData[x, z].Type != TileType.Floor) continue;

                    if (TileOccupied(x, z, currentTurnCharacter, inBattleCharactersPlayer, inBattleEnemies) == true) continue;

                    Vector3 newTilePosition = new Vector3((float)mapData.TileData[x, z].X, 0.0f, (float)mapData.TileData[x, z].Z);
                    GameObject newTile = Instantiate(tilePrefab, newTilePosition, Quaternion.identity);
                    bool targetInRange = TargetsInAttackRange(x, z, currentTurnCharacter.AttackRange);

                    newTile.GetComponent<Tile_MovableInBattle>().SetDetails(mapData.TileData[x, z], targetInRange);

                    MovableTiles.Add(newTile);
                }
            }
        }

        private bool TargetsInAttackRange(int x, int z, int attackRange)
        {
            for (int i = 0; i < turnController.OppositeSide.Count; i++)
            {
                if ((Mathf.Abs(turnController.OppositeSide[i].StandingTileX - x) + Mathf.Abs(turnController.OppositeSide[i].StandingTileZ - z)) <= attackRange) return true;
            }

            return false;
        }

        private bool TileOccupied(int x, int z, Character_InBattle currentTurnCharacter, List<Character_InBattle> inBattleCharactersPlayer, List<Character_InBattle> inBattleEnemies)
        {
            for (int i = 0; i < inBattleCharactersPlayer.Count; i++)
            {
                if (currentTurnCharacter == inBattleCharactersPlayer[i]) continue;

                if ((x == inBattleCharactersPlayer[i].StandingTileX) && (z == inBattleCharactersPlayer[i].StandingTileZ)) return true;
            }

            for (int i = 0; i < inBattleEnemies.Count; i++)
            {
                if (currentTurnCharacter == inBattleEnemies[i]) continue;

                if ((x == inBattleEnemies[i].StandingTileX) && (z == inBattleEnemies[i].StandingTileZ)) return true;
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
