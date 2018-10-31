using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using MapDataSet;

namespace Battle
{
    public class Battle_PhaseMoving : Battle_PhaseBase
    {
        public Character_State runBattle;

        private Character_InBattle currentTurnCharacter;

        public override void ClickWork()
        {

        }

        public override void ClosePhase()
        {

        }

        public override void EnterPhase()
        {
            print("Phase Moving.");

            currentTurnCharacter = turnController.CurrentTurnCharacter;

            currentTurnCharacter.SetTrack();
            currentTurnCharacter.SetState(runBattle);
        }

        // Update is called once per frame
        void Update()
        {
            currentTurnCharacter.Move();

            if (currentTurnCharacter.Arrived == true) phaseManager.EnterNextPhase();
        }
    }
}
