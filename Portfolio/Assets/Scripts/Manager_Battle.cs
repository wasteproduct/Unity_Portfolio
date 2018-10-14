using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using MapDataSet;
using Character;
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
            while(true)
            {
                if (CurrentTurnCharacter.ActionFinished() == true) break;

                yield return null;
            }

            CurrentTurnCharacter = turnController.SetCurrentTurnCharacter(inBattleCharactersPlayer, inBattleEnemies);
            SetMovableTiles();
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
