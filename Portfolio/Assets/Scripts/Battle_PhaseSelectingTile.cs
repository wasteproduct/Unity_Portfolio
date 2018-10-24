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

        public override void ClickWork()
        {
            if (movableTilesManager.OutOfMovableRange(clickEvent.destinationTile))
            {
                print("Out of movable range.");
                return;
            }

            phaseManager.EnterNextPhase();
        }

        public override void ClosePhase()
        {

        }

        public override void EnterPhase()
        {
            print("Phase Selecting Tile.");

            movableTilesManager.SetTiles();

            //if (turnController.EnemyTurn == true)
            //{
            //    aiManager.SetChasedTarget();

            //}
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
