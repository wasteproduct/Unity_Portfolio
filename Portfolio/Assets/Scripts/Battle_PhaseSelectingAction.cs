using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseSelectingAction : Battle_PhaseBase
    {
        [SerializeField]
        private Battle_ActionManager actionManager;
        [SerializeField]
        private GameObject availableActionsList;
        [SerializeField]
        private Battle_AIManager aIManager;

        public void SelectAction(Battle_Action selectedAction)
        {
            actionManager.SetExecutedAction(selectedAction);

            availableActionsList.GetComponent<Battle_ActionSelectingManager>().DisableButtons();
            availableActionsList.gameObject.SetActive(false);

            phaseManager.EnterNextPhase();
        }

        public override void ClickWork()
        {

        }

        public override void ClosePhase()
        {

        }

        public override void EnterPhase()
        {
            //print("Phase Selecting Action.");

            int actionsNumber = actionManager.ExecutableActions.Count;

            if (actionsNumber <= 0)
            {
                actionManager.SetExecutedAction(null);
                phaseManager.EnterNextPhase();
                return;
            }

            if (actionsNumber == 1)
            {
                actionManager.SetExecutedAction(actionManager.ExecutableActions[0]);
                phaseManager.EnterNextPhase();
                return;
            }

            if (actionsNumber > 1)
            {
                if (turnController.EnemyTurn == true) aIManager.SelectAction(actionManager);
                else
                {
                    availableActionsList.gameObject.SetActive(true);
                    availableActionsList.GetComponent<Battle_ActionSelectingManager>().SetList();
                }
            }
        }
    }
}
