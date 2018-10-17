using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Turn Controller", order = 1)]
    public class Battle_TurnController : ScriptableObject
    {
        public Variable_Bool enemyTurn;

        private bool playerTurn;

        public int CurrentTurn { get; private set; }
        public List<Character_InBattle> OppositeSide { get; private set; }

        public void Initialize(List<Character_InBattle> inBattleEnemies)
        {
            CurrentTurn = 1;
            OppositeSide = null;
            enemyTurn.flag = false;
            playerTurn = true;

            OppositeSide = inBattleEnemies;
        }

        public Character_InBattle SetCurrentTurnCharacter(List<Character_InBattle> inBattleCharactersPlayer, List<Character_InBattle> inBattleEnemies, bool rewind)
        {
            CurrentTurn++;

            playerTurn = !playerTurn;

            Character_InBattle result = null;

            // 모든 행동이 끝나고 다시 하는 거다
            if (rewind == true)
            {
                playerTurn = true;

                OppositeSide = inBattleEnemies;

                result = FindCurrentTurnCharacter(inBattleCharactersPlayer);
            }
            // 아직 진행 중이다
            else
            {
                // 플레이어 턴
                if (playerTurn == true)
                {
                    // 플레이어의 적은 적
                    OppositeSide = inBattleEnemies;

                    // 찾아라
                    result = FindCurrentTurnCharacter(inBattleCharactersPlayer);

                    // 못 찾았으면 플레이어 캐릭터 전원 행동 완료, 적에게 턴 넘김
                    if (result == null)
                    {
                        // 적 턴
                        playerTurn = false;

                        // 적의 적은 플레이어
                        OppositeSide = inBattleCharactersPlayer;

                        // 찾아라
                        result = FindCurrentTurnCharacter(inBattleEnemies);
                    }
                }
                // 적 턴 진입
                else
                {
                    // 적의 적은 플레이어
                    OppositeSide = inBattleCharactersPlayer;

                    // 찾아라
                    result = FindCurrentTurnCharacter(inBattleEnemies);

                    // 못 찾았으면 적 전원 행동 완료, 플레이어에게 턴 넘겨라
                    if (result == null)
                    {
                        // 다시 플레이어 턴
                        playerTurn = true;

                        // 플레어의 적은 적
                        OppositeSide = inBattleEnemies;

                        // 찾아라
                        result = FindCurrentTurnCharacter(inBattleCharactersPlayer);
                    }
                }
            }

            enemyTurn.flag = !playerTurn;

            return result;
        }

        private void ResetMaterials(List<Character_InBattle> inBattleCharactersPlayer, List<Character_InBattle> inBattleEnemies)
        {
            for (int i = 0; i < inBattleCharactersPlayer.Count; i++)
            {
                inBattleCharactersPlayer[i].HighlightAsTarget(false);
            }

            for (int i = 0; i < inBattleEnemies.Count; i++)
            {
                inBattleEnemies[i].HighlightAsTarget(false);
            }
        }

        private Character_InBattle FindCurrentTurnCharacter(List<Character_InBattle> currentTurnSide)
        {
            for (int i = 0; i < currentTurnSide.Count; i++)
            {
                if (currentTurnSide[i].TurnFinished == true) continue;

                Camera.main.GetComponent<Camera_Movement>().SetFocus(currentTurnSide[i].gameObject);

                return currentTurnSide[i];
            }

            return null;
        }
    }
}
