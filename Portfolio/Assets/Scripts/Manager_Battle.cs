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
        public GameObject tileMap;

        public Player_Team playerTeam;
        //public ENEMY enemies

        public Battle_TurnController turnController;
        public Battle_MovableTilesManager movableTilesManager;

        private bool acting;
        private Map_Data mapData;
        //private Character_InBattle currentTurnCharacter;

        // temporary

        public void Initialize()
        {
            mapData = tileMap.GetComponent<Map_Main>().MapData;

            acting = false;

            movableTilesManager.Initialize();

            //playerTeam.Initialize_Battle(mapData);
            //enemies.Initialize();

            turnController.Initialize();

            //currentTurnCharacter = playerTeam.InBattleCharacters[0];

            ReadyForAction();
        }

        // Update is called once per frame
        void Update()
        {
            if (acting == true) return;

            

            //StartCoroutine(CharacterAction());
        }

        public void ReadyForAction()
        {
            SetMovableTiles();
        }

        private void SetMovableTiles()
        {
            //movableTilesManager.SetTiles(mapData, currentTurnCharacter.StandingTile.X, currentTurnCharacter.StandingTile.Z);
        }

        //private IEnumerator CharacterAction()
        //{
        //    acting = true;

        //    yield return null;
        //}
    }
}
