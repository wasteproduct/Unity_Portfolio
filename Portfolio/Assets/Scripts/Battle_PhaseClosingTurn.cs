using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseClosingTurn : Battle_PhaseBase
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
            print("Phase Closing Turn.");

            // 데미지 계산, 사망 여부, 피격 액션 등등
            //if(targetManager.)

            phaseManager.EnterNextPhase();
        }
    }
}
