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
        public GameObject dungeonPlayManager;
        public Character_State idleExploration;
        public Variable_Quaternion rotationBattleStatus;
        public Variable_GameObject captain;

        private bool battleStarted = false;

        public void ClickWork()
        {
            battlePhaseManager.CurrentPhase.ClickWork();
        }

        public void FinishBattle()
        {
            battleStarted = false;

            // 전투 결과 반영

            // 탐험 모드
            List<Character_InBattle> playerCharacters = turnController.PlayerCharacters;
            for (int i = 0; i < playerCharacters.Count; i++)
            {
                playerCharacters[i].FinishBattle();
                playerCharacters[i].SetState(idleExploration);
            }
            Camera.main.GetComponent<Camera_Movement>().ChangeFocus(captain.value);

            // 타일 제거
            movableTilesManager.ClearTilesList();

            dungeonPlayManager.GetComponent<Manager_DungeonPlay>().FinishBattle();
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

            Battle_PhaseBase[] phases = new Battle_PhaseBase[6];
            phases[0] = GetComponent<Battle_PhaseSelectingTile>();
            phases[1] = GetComponent<Battle_PhaseMoving>();
            phases[2] = GetComponent<Battle_PhaseSelectingTarget>();
            phases[3] = GetComponent<Battle_PhaseSelectingAction>();
            phases[4] = GetComponent<Battle_PhaseAction>();
            phases[5] = GetComponent<Battle_PhaseClosingTurn>();

            battlePhaseManager.Initialize(phases);

            battleStarted = true;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (battleStarted == false) return;

            rotationBattleStatus.value = CalculateBattleStatusRotation();
        }

        private Quaternion CalculateBattleStatusRotation()
        {
            Character_InBattle currentTurnCharacter = turnController.CurrentTurnCharacter;

            Vector3 forward = currentTurnCharacter.battleStatus.transform.position - Camera.main.transform.position;
            forward.Normalize();

            return Quaternion.LookRotation(forward, Vector3.up);
        }
    }
}
