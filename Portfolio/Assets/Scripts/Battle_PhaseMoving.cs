using UnityEngine;

namespace Battle
{
    public class Battle_PhaseMoving : Battle_PhaseBase
    {
        [SerializeField]
        private Character_State runBattle;
        [SerializeField]
        private Battle_MovableTilesManager movableTilesManager;

        private Character_InBattle currentTurnCharacter;

        public override void ClickWork()
        {

        }

        public override void ClosePhase()
        {

        }

        public override void EnterPhase()
        {
            //print("Phase Moving.");

            if (movableTilesManager.NoMoving == true)
            {
                phaseManager.EnterNextPhase();
                return;
            }

            currentTurnCharacter = turnController.CurrentTurnCharacter;

            currentTurnCharacter.SetTrack();
            currentTurnCharacter.SetState(runBattle);
        }

        // Update is called once per frame
        void Update()
        {
            if (movableTilesManager.NoMoving == true) return;

            currentTurnCharacter.Move();

            if (currentTurnCharacter.Arrived == true) phaseManager.EnterNextPhase();
        }
    }
}
