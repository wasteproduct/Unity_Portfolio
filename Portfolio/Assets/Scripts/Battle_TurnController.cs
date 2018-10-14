using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Turn Controller", order = 1)]
    public class Battle_TurnController : ScriptableObject
    {
        private readonly int playerTurn = 0;
        private readonly int enemyTurn = 1;

        public int CurrentTurn { get; private set; }

        public void Initialize()
        {
            CurrentTurn = playerTurn;
        }

        public Character_InBattle SetCurrentTurnCharacter(List<Character_InBattle> inBattleCharactersPlayer, List<Character_InBattle> inBattleEnemies)
        {
            for (int i = 0; i < inBattleCharactersPlayer.Count; i++)
            {
                if (inBattleCharactersPlayer[i].TurnFinished == true) continue;

                Camera.main.GetComponent<Camera_Movement>().SetFocus(inBattleCharactersPlayer[i].gameObject);
                return inBattleCharactersPlayer[i];
            }

            //CurrentTurn++;
            //if (CurrentTurn % 2 == playerTurn)
            //{

            //}
            //else
            //{

            //}

            return null;
        }
    }
}
