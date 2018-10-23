using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Turn Controller", order = 1)]
    public class Battle_TurnController : ScriptableObject
    {
        public Calculation_Move moveController;

        private const int playerTurn = 0;
        private const int enemyTurn = 1;
        private readonly int turnMax = 2;
        private int currentTurn;

        public Character_InBattle CurrentTurnCharacter { get; private set; }
        public List<Character_InBattle> PlayerCharacters { get; private set; }
        public List<Character_InBattle> EnemyCharacters { get; private set; }
        public List<Character_InBattle> OppositeSide { get; private set; }
        public float ElapsedTimeLimit { get { return moveController.ElapsedTimeLimit; } }

        public void Initialize(List<GameObject> playerCharacters, List<GameObject> enemiesInZone)
        {
            SetPlayerCharacters(playerCharacters);
            SetEnemyCharacters(enemiesInZone);

            ResetTurns();
        }

        public void SwitchTurn()
        {
            CurrentTurnCharacter.SetTurnFinished(true);

            for (int i = 0; i < 2; i++)
            {
                SetCurrentTurnCharacter();

                if (CurrentTurnCharacter != null) break;
            }

            // Rewind
            if (CurrentTurnCharacter == null) ResetTurns();
        }

        private void ResetTurns()
        {
            for (int i = 0; i < EnemyCharacters.Count; i++)
            {
                EnemyCharacters[i].SetTurnFinished(false);
            }

            for (int i = 0; i < PlayerCharacters.Count; i++)
            {
                PlayerCharacters[i].SetTurnFinished(false);
            }

            currentTurn = playerTurn;
            CurrentTurnCharacter = PlayerCharacters[0];
            OppositeSide = EnemyCharacters;
        }

        private void SetCurrentTurnCharacter()
        {
            CurrentTurnCharacter = null;

            currentTurn++;
            if (currentTurn >= turnMax) currentTurn -= turnMax;

            for (int i = 0; i < OppositeSide.Count; i++)
            {
                if (OppositeSide[i].TurnFinished == false)
                {
                    CurrentTurnCharacter = OppositeSide[i];
                    break;
                }
            }

            switch (currentTurn)
            {
                case playerTurn:
                    OppositeSide = EnemyCharacters;
                    break;
                case enemyTurn:
                    OppositeSide = PlayerCharacters;
                    break;
                default:
                    Debug.Log("Invalid turn value.");
                    break;
            }
        }

        private void SetEnemyCharacters(List<GameObject> enemiesInZone)
        {
            EnemyCharacters = new List<Character_InBattle>();

            for (int i = 0; i < enemiesInZone.Count; i++)
            {
                if (enemiesInZone[i].GetComponent<Character_InBattle>().Dead == true)
                {
                    enemiesInZone[i].gameObject.SetActive(false);
                    continue;
                }

                EnemyCharacters.Add(enemiesInZone[i].GetComponent<Character_InBattle>());
            }
        }

        private void SetPlayerCharacters(List<GameObject> playerCharacters)
        {
            PlayerCharacters = new List<Character_InBattle>();

            for (int i = 0; i < playerCharacters.Count; i++)
            {
                if (playerCharacters[i].GetComponent<Character_InBattle>().Dead == true)
                {
                    playerCharacters[i].gameObject.SetActive(false);
                    continue;
                }

                PlayerCharacters.Add(playerCharacters[i].GetComponent<Character_InBattle>());
            }
        }
















        /// <summary>
        /// FAILURE
        /// </summary>
        //public Variable_Bool enemyTurn;

        //private bool playerTurn;

        //public int CurrentTurn { get; private set; }

        public void Initialize(List<Character_InBattle> inBattleEnemies)
        {
            //CurrentTurn = 1;
            OppositeSide = null;
            //enemyTurn.flag = false;
            //playerTurn = true;

            OppositeSide = inBattleEnemies;
        }

        public Character_InBattle SetCurrentTurnCharacter(List<Character_InBattle> inBattleCharactersPlayer, List<Character_InBattle> inBattleEnemies, bool rewind)
        {
            //CurrentTurn++;

            //playerTurn = !playerTurn;

            Character_InBattle result = null;

            // 모든 행동이 끝나고 다시 하는 거다
            if (rewind == true)
            {
                //playerTurn = true;

                OppositeSide = inBattleEnemies;

                result = FindCurrentTurnCharacter(inBattleCharactersPlayer);
            }
            // 아직 진행 중이다
            else
            {
                // 플레이어 턴
                //if (playerTurn == true)
                //{
                //    // 플레이어의 적은 적
                //    OppositeSide = inBattleEnemies;

                //    // 찾아라
                //    result = FindCurrentTurnCharacter(inBattleCharactersPlayer);

                //    // 못 찾았으면 플레이어 캐릭터 전원 행동 완료, 적에게 턴 넘김
                //    if (result == null)
                //    {
                //        // 적 턴
                //        playerTurn = false;

                //        // 적의 적은 플레이어
                //        OppositeSide = inBattleCharactersPlayer;

                //        // 찾아라
                //        result = FindCurrentTurnCharacter(inBattleEnemies);
                //    }
                //}
                //// 적 턴 진입
                //else
                //{
                //    // 적의 적은 플레이어
                //    OppositeSide = inBattleCharactersPlayer;

                //    // 찾아라
                //    result = FindCurrentTurnCharacter(inBattleEnemies);

                //    // 못 찾았으면 적 전원 행동 완료, 플레이어에게 턴 넘겨라
                //    if (result == null)
                //    {
                //        // 다시 플레이어 턴
                //        playerTurn = true;

                //        // 플레어의 적은 적
                //        OppositeSide = inBattleEnemies;

                //        // 찾아라
                //        result = FindCurrentTurnCharacter(inBattleCharactersPlayer);
                //    }
                //}
            }

            //enemyTurn.flag = !playerTurn;

            return result;
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
