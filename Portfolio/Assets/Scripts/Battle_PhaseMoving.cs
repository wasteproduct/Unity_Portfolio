using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using MapDataSet;

namespace Battle
{
    public class Battle_PhaseMoving : Battle_PhaseBase
    {
        public Calculation_AStar aStar;
        
        private Character_InBattle currentTurnCharacter;
        private List<Node_AStar> track;
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
            print("Phase Moving.");
            
            currentTurnCharacter = turnController.CurrentTurnCharacter;

            SetTrack();

            elapsedTime = 0.0f;
            lerpTime = 0.0f;
            targetIndex = 1;
            elapsedTimeLimit = turnController.ElapsedTimeLimit;
        }

        private void SetTrack()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (elapsedTime >= elapsedTimeLimit)
            {
                elapsedTime = 0.0f;
                targetIndex++;

                if (targetIndex > turnController.CurrentTurnCharacter.MovableDistance)
                {
                    phaseManager.EnterNextPhase();
                    return;
                }
            }

            elapsedTime += Time.deltaTime;

            lerpTime = elapsedTime / elapsedTimeLimit;

            //turnController.CurrentTurnCharacter.Move(targetIndex, lerpTime);
        }
    }
}
