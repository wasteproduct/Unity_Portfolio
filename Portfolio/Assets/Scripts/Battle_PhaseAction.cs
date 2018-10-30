using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseAction : Battle_PhaseBase
    {
        public Battle_TargetManager targetManager;
        public Battle_ActionManager actionManager;
        public Calculation_Turn rotationCalculator;

        public override void ClickWork()
        {

        }

        public override void ClosePhase()
        {
            turnController.SwitchTurn();
        }

        public override void EnterPhase()
        {
            print("Phase Action.");

            if ((targetManager.TargetFound == false) || (actionManager.ExecutedAction == null))
            {
                phaseManager.EnterNextPhase();
                return;
            }

            StartCoroutine(HeadToTarget());
        }

        private IEnumerator HeadToTarget()
        {
            Character_InBattle currentTurnCharacter = turnController.CurrentTurnCharacter;
            while(true)
            {
                currentTurnCharacter.HeadToTarget();

                yield return null;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
