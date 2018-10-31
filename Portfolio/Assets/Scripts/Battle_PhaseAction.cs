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

            StartCoroutine(ExecuteAction());
        }

        private IEnumerator ExecuteAction()
        {
            Character_InBattle currentTurnCharacter = turnController.CurrentTurnCharacter;

            currentTurnCharacter.SetTargetRotation(targetManager.Target.gameObject.transform.position);

            while (true)
            {
                currentTurnCharacter.HeadToTarget();

                if (currentTurnCharacter.StartAction == true) break;

                yield return null;
            }

            Battle_Action executedAction = actionManager.ExecutedAction;

            currentTurnCharacter.SetState(executedAction.actionState);

            // 데미지 계산, 체력 계산, 사망 처리 등등
            //actionManager.ExecutedAction.Play();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
