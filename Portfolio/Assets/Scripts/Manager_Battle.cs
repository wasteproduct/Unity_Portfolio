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
            StartCoroutine(CurrentTurnCharacterAction());
        }

        public void Initialize()
        {
            playerManager = player.GetComponent<Player_DungeonSettings>();

            movableTilesManager.Initialize(tileMap.GetComponent<Map_Main>().MapData);
            turnController.Initialize();

            SetPlayerCharacters();

            SetEnemies();

            CurrentTurnCharacter = inBattleCharactersPlayer[0];
            SetMovableTiles();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SetMovableTiles()
        {
            Character_Explore currentTurnCharacterMoveController = CurrentTurnCharacter.gameObject.GetComponent<Character_InDungeon>().MoveController;
            movableTilesManager.SetTiles(currentTurnCharacterMoveController.StandingTileX, currentTurnCharacterMoveController.StandingTileZ);
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
            SetMovableTiles();
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

        private void SetEnemies()
        {
            inBattleEnemies = new List<Character_InBattle>();
        }

        public void FinishBattle()
        {

        }
    }
}
