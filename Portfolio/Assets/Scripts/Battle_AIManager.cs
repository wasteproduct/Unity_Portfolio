using System.Collections.Generic;
using UnityEngine;
using TileDataSet;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/AI Manager", order = 1)]
    public class Battle_AIManager : ScriptableObject
    {
        public Battle_TurnController turnController;
        public Battle_MovableTilesManager movableTilesManager;

        public GameObject ChasedTarget { get; private set; }

        public void SetDestinationTile()
        {
            List<GameObject> movableTiles = movableTilesManager.MovableTiles;

            int targetX = ChasedTarget.GetComponent<Character_InBattle>().StandingTileX;
            int targetZ = ChasedTarget.GetComponent<Character_InBattle>().StandingTileZ;

            int shortestDistance = 99999999;

            for (int i = 0; i < movableTiles.Count; i++)
            {
                int tileX = movableTiles[i].GetComponent<Tile_MovableInBattle>().TileData.X;
                int tileZ = movableTiles[i].GetComponent<Tile_MovableInBattle>().TileData.Z;

                int xDistance = Mathf.Abs(targetX - tileX);
                int zDistance = Mathf.Abs(targetZ - tileZ);

                int distance = xDistance + zDistance;

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    movableTilesManager.SetDestinationTile(movableTiles[i].GetComponent<Tile_MovableInBattle>().TileData);
                }
            }
        }

        public void SetChasedTarget()
        {
            ChasedTarget = null;

            // 거리에 따른
            int closestDistance = 99999999;
            List<Character_InBattle> playerCharacters = turnController.PlayerCharacters;
            Character_InBattle currentEnemy = turnController.CurrentTurnCharacter;

            for (int i = 0; i < playerCharacters.Count; i++)
            {
                int xDistance = Mathf.Abs(playerCharacters[i].StandingTileX - currentEnemy.StandingTileX);
                int zDistance = Mathf.Abs(playerCharacters[i].StandingTileZ - currentEnemy.StandingTileZ);

                int distance = xDistance + zDistance;

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    ChasedTarget = playerCharacters[i].gameObject;
                }
            }

            // 타입에 따른

            // 체력에 따른
        }
    }
}
