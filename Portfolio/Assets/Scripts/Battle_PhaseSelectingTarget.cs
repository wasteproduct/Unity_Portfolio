using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseSelectingTarget : Battle_PhaseBase
    {
        public Battle_TargetManager targetManager;
        public Variable_Bool choosingTarget;
        public Manager_Layers layers;

        public override void ClickWork()
        {

        }

        public override void ClosePhase()
        {
            choosingTarget.flag = false;
            
            targetManager.RemoveMarks();
        }

        public override void EnterPhase()
        {
            print("Phase Selecting Target.");

            targetManager.SearchTargets();

            if (targetManager.TargetFound == false)
            {
                phaseManager.EnterNextPhase();
                return;
            }

            if (targetManager.OnlyOneTarget == true)
            {
                targetManager.SelectedTarget = targetManager.PotentialTargets[0];
                phaseManager.EnterNextPhase();
                return;
            }
            
            targetManager.MarkAvailableTargets();

            print("Select Target");
        }

        // Update is called once per frame
        void Update()
        {
            targetManager.Update();

            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                
                if (Physics.Raycast(ray, out hitInfo, 100.0f) == true)
                {
                    if ((1 << hitInfo.collider.gameObject.layer) == layers.Enemy)
                    {
                        GameObject clickedEnemy = hitInfo.collider.gameObject;
                        List<GameObject> potentialTargets = targetManager.PotentialTargets;

                        for (int i = 0; i < potentialTargets.Count; i++)
                        {
                            if (clickedEnemy == potentialTargets[i])
                            {
                                targetManager.SelectedTarget = clickedEnemy;
                                phaseManager.EnterNextPhase();
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
