using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseAction : Battle_PhaseBase
    {
        public Battle_TargetManager targetManager;
        public Battle_ActionManager actionManager;

        public override void ClickWork()
        {

        }

        public override void ClosePhase()
        {
            
        }

        public override void EnterPhase()
        {
            print("Phase Action.");

            if (actionManager.NothingToDo == true)
            {
                phaseManager.EnterNextPhase();
                return;
            }

            StartCoroutine(ExecuteAction());
        }

        private IEnumerator ExecuteAction()
        {
            Character_InBattle currentTurnCharacter = turnController.CurrentTurnCharacter;

            currentTurnCharacter.SetTargetRotation(targetManager.SelectedTarget.gameObject.transform.position);

            while (true)
            {
                currentTurnCharacter.HeadToTarget();

                if (currentTurnCharacter.StartAction == true) break;

                yield return null;
            }
            
            actionManager.ExecutedAction.Play();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
