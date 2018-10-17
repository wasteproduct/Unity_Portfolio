using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using TileDataSet;

namespace Battle
{
    public class Manager_Battle : MonoBehaviour
    {
        public GameObject player;
        public GameObject tileMap;
        public Battle_MovableTilesManager movableTilesManager;
        public Battle_TurnController turnController;
        public Variable_Bool enemyTurn;
        public Battle_TargetManager targetManager;

        private Player_DungeonSettings playerManager;
        private List<Character_InBattle> inBattleCharactersPlayer;
        private List<Character_InBattle> inBattleEnemies;

        public Character_InBattle CurrentTurnCharacter { get; private set; }
        public bool OutOfMovableRange(Map_TileData destinationTile)
        {
            return movableTilesManager.OutOfMovableRange(destinationTile);
        }

        public void StartAction()
        {
            if (targetManager.Targets.Count > 1) StartCoroutine(PickTarget());
            StartCoroutine(CurrentTurnCharacterAction());
        }

        public void Initialize(List<GameObject> enemiesInZone)
        {
            playerManager = player.GetComponent<Player_DungeonSettings>();

            movableTilesManager.Initialize(tileMap.GetComponent<Map_Main>().MapData);
            turnController.Initialize();

            SetPlayerCharacters();

            SetEnemies(enemiesInZone);

            CurrentTurnCharacter = inBattleCharactersPlayer[0];
            movableTilesManager.SetTiles(CurrentTurnCharacter, inBattleCharactersPlayer, inBattleEnemies);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private IEnumerator CurrentTurnCharacterAction()
        {
            while (true)
            {
                if (CurrentTurnCharacter.ActionFinished() == true) break;

                yield return null;
            }

            if (AllFinishedTurn() == true)
            {
                if (BattleOver() == true)
                {

                }
                else
                {
                    RecoverTurns();
                }
            }

            CurrentTurnCharacter = turnController.SetCurrentTurnCharacter(inBattleCharactersPlayer, inBattleEnemies);
            movableTilesManager.SetTiles(CurrentTurnCharacter, inBattleCharactersPlayer, inBattleEnemies);
            if (enemyTurn.flag == true) StartCoroutine(CurrentTurnCharacterAction());
        }

        private IEnumerator PickTarget()
        {
            bool picked = false;

            for (int i = 0; i < targetManager.Targets.Count; i++)
            {
                targetManager.Targets[i].GetComponent<Character_InBattle>().HighlightAsTarget(true);
            }

            while (true)
            {
                // must work with cursor??


                if (picked == true)
                {
                    for (int i = 0; i < targetManager.Targets.Count; i++)
                    {
                        targetManager.Targets[i].GetComponent<Character_InBattle>().HighlightAsTarget(false);
                    }

                    break;
                }

                yield return null;
            }
        }

        private void RecoverTurns()
        {
            for (int i = 0; i < inBattleCharactersPlayer.Count; i++)
            {
                inBattleCharactersPlayer[i].SetTurnFinished(false);
            }

            for (int i = 0; i < inBattleEnemies.Count; i++)
            {
                inBattleEnemies[i].SetTurnFinished(false);
            }
        }

        private bool BattleOver()
        {
            return false;
        }

        private bool AllFinishedTurn()
        {
            for (int i = 0; i < inBattleCharactersPlayer.Count; i++)
            {
                if (inBattleCharactersPlayer[i].TurnFinished == false) return false;
            }

            for (int i = 0; i < inBattleEnemies.Count; i++)
            {
                if (inBattleEnemies[i].TurnFinished == false) return false;
            }

            return true;
        }

        private void SetPlayerCharacters()
        {
            inBattleCharactersPlayer = new List<Character_InBattle>();

            for (int i = 0; i < playerManager.PlayerCharacters.Count; i++)
            {
                if (playerManager.PlayerCharacters[i].GetComponent<Character_InBattle>().Dead == true)
                {
                    playerManager.PlayerCharacters[i].gameObject.SetActive(false);
                    continue;
                }

                inBattleCharactersPlayer.Add(playerManager.PlayerCharacters[i].GetComponent<Character_InBattle>());
            }
        }

        private void SetEnemies(List<GameObject> enemiesInZone)
        {
            inBattleEnemies = new List<Character_InBattle>();

            for (int i = 0; i < enemiesInZone.Count; i++)
            {
                enemiesInZone[i].GetComponent<Character_InBattle>().Initialize(tileMap.GetComponent<Map_Main>().MapData);
                inBattleEnemies.Add(enemiesInZone[i].GetComponent<Character_InBattle>());
            }
        }

        public void FinishBattle()
        {

        }
    }
}
