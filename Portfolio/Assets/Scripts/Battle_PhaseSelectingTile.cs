using UnityEngine;

namespace Battle
{
    public class Battle_PhaseSelectingTile : Battle_PhaseBase
    {
        [SerializeField]
        private Battle_MovableTilesManager movableTilesManager;
        [SerializeField]
        private Event_Click clickEvent;
        [SerializeField]
        private Battle_AIManager aIManager;
        [SerializeField]
        private Battle_ActionManager actionManager;

        public override void ClickWork()
        {
            if (movableTilesManager.OutOfMovableRange(clickEvent.destinationTile))
            {
                print("Out of movable range.");
                return;
            }

            movableTilesManager.SetDestinationTile(clickEvent.destinationTile);

            phaseManager.EnterNextPhase();
        }

        public override void ClosePhase()
        {
            actionManager.SetExecutableActions();
        }

        public override void EnterPhase()
        {
            //print("Phase Selecting Tile.");

            movableTilesManager.SetTiles();

            if (turnController.EnemyTurn == true)
            {
                aIManager.SetDestination();
                phaseManager.EnterNextPhase();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
