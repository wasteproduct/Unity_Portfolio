using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Battle_PhaseSelectingTarget : Battle_PhaseBase
    {
        [SerializeField]
        private Battle_TargetManager targetManager;
        [SerializeField]
        private Battle_ActionManager actionManager;
        [SerializeField]
        private Variable_Bool choosingTarget;
        [SerializeField]
        private Manager_Layers layers;
        [SerializeField]
        private Battle_AIManager aIManager;

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

            if (turnController.EnemyTurn == true)
            {
                aIManager.SelectTarget(targetManager);
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
                Ray ray = PassedRay();
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
                                targetManager.SelectedTarget = clickedTarget;
                                phaseManager.EnterNextPhase();
                                return;
                            }
                        }
                    }
                }
            }
        }

        private Ray PassedRay()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            Ray result = new Ray();

            if (Physics.Raycast(ray, out hitInfo, 100.0f) == true)
            {
                if (1 << hitInfo.collider.gameObject.layer == layers.FogOfWar)
                {
                    result.origin = hitInfo.point + ray.direction * .2f;
                    result.direction = ray.direction;
                }
            }

            Debug.DrawLine(ray.origin, result.origin, Color.red);

            return result;
        }
    }
}
