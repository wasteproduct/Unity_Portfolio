using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseClosingTurn : Battle_PhaseBase
    {
        public Battle_TargetManager targetManager;
        public Battle_MovableTilesManager movableTilesManager;

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

            movableTilesManager.ClearTilesList();

            StartCoroutine(FinalProcess());
        }

        private IEnumerator FinalProcess()
        {
            yield return new WaitForSeconds(1.0f);

            turnController.RemoveDeadCharacters();

            bool allEnemiesDead = turnController.CheckAllEnemiesDead();

            if (allEnemiesDead == true) gameObject.GetComponent<Manager_Battle2>().FinishBattle();
            else phaseManager.EnterNextPhase();
        }
    }
}
