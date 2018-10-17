using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Turn Controller", order = 1)]
    public class Battle_TurnController : ScriptableObject
    {
        public Variable_Bool enemyTurn;

        private readonly int playerTurn = 1;

        public int CurrentTurn { get; private set; }

        public void Initialize()
        {
            CurrentTurn = playerTurn;
            enemyTurn.flag = false;
        }

        public Character_InBattle SetCurrentTurnCharacter(List<Character_InBattle> inBattleCharactersPlayer, List<Character_InBattle> inBattleEnemies)
        {
            CurrentTurn++;

            if (CurrentTurn % 2 == playerTurn)
            {
                for (int i = 0; i < inBattleCharactersPlayer.Count; i++)
                {
                    if (inBattleCharactersPlayer[i].TurnFinished == true) continue;

                    enemyTurn.flag = false;

                    Camera.main.GetComponent<Camera_Movement>().SetFocus(inBattleCharactersPlayer[i].gameObject);

                    return inBattleCharactersPlayer[i];
                }
            }
            else
            {
                for (int i = 0; i < inBattleEnemies.Count; i++)
                {
                    if (inBattleEnemies[i].TurnFinished == true) continue;

                    enemyTurn.flag = true;

                    Camera.main.GetComponent<Camera_Movement>().SetFocus(inBattleEnemies[i].gameObject);

                    return inBattleEnemies[i];
                }
            }

            return null;
        }
    }
}
