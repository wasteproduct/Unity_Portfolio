using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseSelectingTile : Battle_PhaseBase
    {
        public Battle_MovableTilesManager movableTilesManager;
        //public Battle_TurnController turnController;

        public override void ClosePhase()
        {

        }

        public override void EnterPhase()
        {
            movableTilesManager.SetTiles();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //if(input. ...)
            //{
            //  startmoving;
            //}
        }
    }
}
