using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseSelectingAction : Battle_PhaseBase
    {
        public Battle_ActionManager actionManager;
        public GameObject availableActionsList;
        public Battle_TargetManager targetManager;

        public void SelectAction(Battle_Action selectedAction)
        {
            actionManager.SetExecutedAction(selectedAction);

            availableActionsList.GetComponent<Battle_ActionSelectingManager>().DisableButtons();
            availableActionsList.gameObject.SetActive(false);

            targetManager.SetFinalTargets(selectedAction.Scale);

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
            print("Phase Selecting Action.");

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
                targetManager.SetFinalTargets(actionManager.ExecutedAction.Scale);
                phaseManager.EnterNextPhase();
                return;
            }

            if (actionsNumber > 1)
            {
                availableActionsList.gameObject.SetActive(true);
                availableActionsList.GetComponent<Battle_ActionSelectingManager>().SetList();
                return;
            }
        }
    }
}
