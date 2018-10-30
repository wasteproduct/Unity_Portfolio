using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseSelectingAction : Battle_PhaseBase
    {
        public Battle_ActionManager actionManager;

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
                phaseManager.EnterNextPhase();
                return;
            }
        }
    }
}
