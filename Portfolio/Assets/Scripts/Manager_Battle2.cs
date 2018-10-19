using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Battle
{
    public class Manager_Battle2 : MonoBehaviour
    {
        public Manager_BattlePhase battlePhaseManager;
        public GameObject player;
        public Battle_TurnController turnController;
        public Battle_MovableTilesManager movableTilesManager;
        public GameObject tileMap;

        private Battle_PhaseSelectingTile phaseSelectingTile;

        public void Initialize(List<GameObject> enemiesInZone)
        {
            phaseSelectingTile = this.gameObject.GetComponent<Battle_PhaseSelectingTile>();

            turnController.Initialize(player.GetComponent<Player_DungeonSettings>().PlayerCharacters, enemiesInZone);
            movableTilesManager.Initialize(tileMap.GetComponent<Map_Main>().MapData);

            phaseSelectingTile.enabled = true;
            phaseSelectingTile.EnterPhase();

            //playerManager = player.GetComponent<Player_DungeonSettings>();

            //movableTilesManager.Initialize(tileMap.GetComponent<Map_Main>().MapData);

            //SetPlayerCharacters();

            //SetEnemies(enemiesInZone);

            //turnController.Initialize(inBattleEnemies);

            //target = null;

            //CurrentTurnCharacter = inBattleCharactersPlayer[0];
            //movableTilesManager.SetTiles(CurrentTurnCharacter, inBattleCharactersPlayer, inBattleEnemies);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
