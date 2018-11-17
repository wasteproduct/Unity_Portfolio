using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseSelectingTile : Battle_PhaseBase
    {
        public Battle_MovableTilesManager movableTilesManager;
        public Event_Click clickEvent;
        public Battle_AIManager aiManager;
        public Battle_ActionManager actionManager;

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
                aiManager.SetChasedTarget();
                aiManager.SetDestinationTile();
                phaseManager.EnterNextPhase();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
