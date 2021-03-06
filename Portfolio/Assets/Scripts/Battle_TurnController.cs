﻿using System.Collections;
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
        public List<Character_InBattle> SameSide { get; private set; }
        public float ElapsedTimeLimit { get { return moveController.ElapsedTimeLimit; } }
        public bool EnemyTurn { get; private set; }

        public bool CheckAllEnemiesDead()
        {
            for (int i = 0; i < EnemyCharacters.Count; i++)
            {
                if (EnemyCharacters[i].Dead == false) return false;
            }

            return true;
        }

        public void RemoveDeadCharacters()
        {
            for (int i = 0; i < PlayerCharacters.Count; i++)
            {
                if (PlayerCharacters[i].Dead == true)
                {
                    Destroy(PlayerCharacters[i].gameObject);

                    PlayerCharacters.RemoveAt(i);
                }
            }

            for (int i = 0; i < EnemyCharacters.Count; i++)
            {
                if (EnemyCharacters[i].Dead == true)
                {
                    Destroy(EnemyCharacters[i].gameObject);

                    EnemyCharacters.RemoveAt(i);
                }
            }
        }

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
            SameSide = PlayerCharacters;
            EnemyTurn = false;
        }

        private void SetCurrentTurnCharacter()
        {
            CurrentTurnCharacter = null;

            currentTurn++;
            if (currentTurn >= turnMax) currentTurn -= turnMax;
            EnemyTurn = !EnemyTurn;

            for (int i = 0; i < OppositeSide.Count; i++)
            {
                if (OppositeSide[i].Dead == true) continue;

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
                    SameSide = PlayerCharacters;
                    break;
                case enemyTurn:
                    OppositeSide = PlayerCharacters;
                    SameSide = EnemyCharacters;
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

                enemiesInZone[i].GetComponent<Character_StateManager>().Initialize();
                enemiesInZone[i].GetComponent<Character_InBattle>().StartBattle();

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

                playerCharacters[i].GetComponent<Character_InBattle>().StartBattle();

                PlayerCharacters.Add(playerCharacters[i].GetComponent<Character_InBattle>());
            }
        }
    }
}
