using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseAction : Battle_PhaseBase
    {
        public Battle_TargetManager targetManager;

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

            if (targetManager.TargetFound == false)
            {
                phaseManager.EnterNextPhase();
                return;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
