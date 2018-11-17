using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseSelectingTarget : Battle_PhaseBase
    {
        public Battle_TargetManager targetManager;
        public Battle_ActionManager actionManager;
        public Variable_Bool choosingTarget;
        public Manager_Layers layers;

        public override void ClickWork()
        {

        }

        public override void ClosePhase()
        {
            targetManager.SetFinalTargets(actionManager.ExecutedAction);

            choosingTarget.flag = false;
            
            targetManager.RemoveMarks();
        }

        public override void EnterPhase()
        {
            //print("Phase Selecting Target.");

            if (actionManager.NothingToDo == true)
            {
                phaseManager.EnterNextPhase();
                return;
            }

            targetManager.SetAvailableTargets(actionManager.ExecutedAction);

            if (targetManager.TargetFound == false)
            {
                phaseManager.EnterNextPhase();
                return;
            }

            if (targetManager.OnlyOneTarget == true)
            {
                targetManager.SelectedTarget = targetManager.AvailableTargets[0];
                phaseManager.EnterNextPhase();
                return;
            }

            choosingTarget.flag = true;
            
            targetManager.MarkAvailableTargets();
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
                    if ((1 << hitInfo.collider.gameObject.layer) == layers.Character)
                    {
                        GameObject clickedTarget = hitInfo.collider.gameObject;
                        List<GameObject> availableTargets = targetManager.AvailableTargets;

                        for (int i = 0; i < availableTargets.Count; i++)
                        {
                            if (clickedTarget == availableTargets[i])
                            {
                                print("hit");
                                targetManager.SelectedTarget = clickedTarget;
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
