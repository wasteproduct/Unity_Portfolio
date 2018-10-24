using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/AI Manager", order = 1)]
    public class Battle_AIManager : ScriptableObject
    {
        public Battle_TurnController turnController;
        public Calculation_AStar aStar;

        public GameObject ChasedTarget { get; private set; }

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
