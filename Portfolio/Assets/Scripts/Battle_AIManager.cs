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

        public Character_InBattle ChasedTarget { get; private set; }

        public void SelectTarget(Battle_TargetManager targetManager)
        {
            List<GameObject> availableTargets = targetManager.AvailableTargets;

            float lowestHPRate = 2.0f;
            GameObject selectedTarget = null;

            for (int i = 0; i < availableTargets.Count; i++)
            {
                Character_ConditionManager targetCondition = availableTargets[i].GetComponent<Character_ConditionManager>();

                float hPRate = targetCondition.CurrentHP / targetCondition.MaximumHP;

                if (hPRate < lowestHPRate)
                {
                    lowestHPRate = hPRate;
                    selectedTarget = availableTargets[i];
                }
            }

            if (selectedTarget == null)
            {
                bool error = true;
                bool stop = error;
            }

            targetManager.SelectedTarget = selectedTarget;
        }

        public void SelectAction(Battle_ActionManager actionManager)
        {
            int actionIndex = Random.Range(0, actionManager.ExecutableActions.Count);

            actionManager.SetExecutedAction(actionManager.ExecutableActions[actionIndex]);
        }

        public void SetDestination()
        {
            List<GameObject> movableTiles = movableTilesManager.MovableTiles;

            List<Tile_MovableInBattle> actionTiles = new List<Tile_MovableInBattle>();

            for (int i = 0; i < movableTiles.Count; i++)
            {
                Tile_MovableInBattle currentTile = movableTiles[i].GetComponent<Tile_MovableInBattle>();

                if (currentTile.AvailableActions.Count > 0) actionTiles.Add(currentTile);
            }

            if (actionTiles.Count > 0) SetDestinationTile(actionTiles);
            else SetChasedTarget();
        }

        private void SetChasedTarget()
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
                    ChasedTarget = playerCharacters[i];
                }
            }

            // 타입에 따른

            // 체력에 따른

            SetDestinationTile();
        }

        private void SetDestinationTile()
        {
            List<GameObject> movableTiles = movableTilesManager.MovableTiles;

            int targetX = ChasedTarget.StandingTileX;
            int targetZ = ChasedTarget.StandingTileZ;

            int shortestDistance = 99999999;
            Map_TileData destinationTile = null;

            for (int i = 0; i < movableTiles.Count; i++)
            {
                Map_TileData currentTile = movableTiles[i].GetComponent<Tile_MovableInBattle>().TileData;

                int xDistance = Mathf.Abs(targetX - currentTile.X);
                int zDistance = Mathf.Abs(targetZ - currentTile.Z);

                int distance = xDistance + zDistance;

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    destinationTile = currentTile;
                }
            }

            if (destinationTile == null)
            {
                bool error = true;
                bool stop = error;
            }

            movableTilesManager.SetDestinationTile(destinationTile);
        }

        private void SetDestinationTile(List<Tile_MovableInBattle> actionTiles)
        {
            int shortestDistance = 99999999;
            Map_TileData destinationTile = null;

            Character_InBattle currentEnemy = turnController.CurrentTurnCharacter;

            for (int i = 0; i < actionTiles.Count; i++)
            {
                int xDistance = Mathf.Abs(actionTiles[i].TileData.X - currentEnemy.StandingTileX);
                int zDistance = Mathf.Abs(actionTiles[i].TileData.Z - currentEnemy.StandingTileZ);

                int distance = xDistance + zDistance;

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    destinationTile = actionTiles[i].TileData;
                }
            }

            if (destinationTile == null)
            {
                bool error = true;
                bool stop = error;
            }

            movableTilesManager.SetDestinationTile(destinationTile);
        }
    }
}
