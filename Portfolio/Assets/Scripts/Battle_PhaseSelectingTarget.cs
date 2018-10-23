using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseSelectingTarget : Battle_PhaseBase
    {
        public Battle_TargetManager targetManager;

        public override void ClickWork()
        {

        }

        public override void ClosePhase()
        {

        }

        public override void EnterPhase()
        {
            print("Phase Selecting Target.");

            targetManager.SearchTargets();

            if (targetManager.TargetFound == false) phaseManager.EnterNextPhase();
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
