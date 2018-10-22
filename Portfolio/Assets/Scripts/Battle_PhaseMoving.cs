using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;

namespace Battle
{
    public class Battle_PhaseMoving : Battle_PhaseBase
    {
        public Battle_TurnController turnController;
        public Calculation_AStar aStar;

        private float elapsedTime;
        private float lerpTime;
        private int targetIndex;
        private float elapsedTimeLimit;

        public override void ClickWork()
        {

        }

        public override void ClosePhase()
        {

        }

        public override void EnterPhase()
        {
            elapsedTime = 0.0f;
            lerpTime = 0.0f;
            targetIndex = 1;
            elapsedTimeLimit = turnController.ElapsedTimeLimit;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            elapsedTime += Time.deltaTime;

            lerpTime = elapsedTime / elapsedTimeLimit;

            turnController.CurrentTurnCharacter.Move(targetIndex, lerpTime);

            if (elapsedTime >= elapsedTimeLimit)
            {
                elapsedTime = 0.0f;
                targetIndex++;

                if (targetIndex >= aStar.FinalTrack.Count)
                {
                    phaseManager.EnterNextPhase();
                }
            }
        }
    }
}
