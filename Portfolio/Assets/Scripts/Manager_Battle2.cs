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

        public void ClickWork()
        {
            battlePhaseManager.CurrentPhase.ClickWork();
        }

        public void Initialize(List<GameObject> enemiesInZone)
        {
            // Initialize enemies
            for (int i = 0; i < enemiesInZone.Count; i++)
            {
                enemiesInZone[i].GetComponent<Character_InBattle>().Initialize(tileMap.GetComponent<Map_Main>().MapData, true);
            }

            turnController.Initialize(player.GetComponent<Player_DungeonSettings>().PlayerCharacters, enemiesInZone);
            movableTilesManager.Initialize(tileMap.GetComponent<Map_Main>().MapData);

            Battle_PhaseBase[] phases = new Battle_PhaseBase[5];
            phases[0] = GetComponent<Battle_PhaseSelectingTile>();
            phases[1] = GetComponent<Battle_PhaseMoving>();
            phases[2] = GetComponent<Battle_PhaseSelectingTarget>();
            phases[3] = GetComponent<Battle_PhaseSelectingAction>();
            phases[4] = GetComponent<Battle_PhaseAction>();

            battlePhaseManager.Initialize(phases);

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
