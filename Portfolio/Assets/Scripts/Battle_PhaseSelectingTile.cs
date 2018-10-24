﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseSelectingTile : Battle_PhaseBase
    {
        public Battle_MovableTilesManager movableTilesManager;
        public Event_Click clickEvent;

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
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
