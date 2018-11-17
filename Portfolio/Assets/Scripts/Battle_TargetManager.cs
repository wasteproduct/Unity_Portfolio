using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Target Manager", order = 1)]
    public class Battle_TargetManager : ScriptableObject
    {
        public Battle_ObjectManager objectManager;
        public Battle_TurnController turnController;
        public Battle_ActionType actionTypeSupport;

        private List<Character_InBattle> searchedSide;

        public List<GameObject> AvailableTargets { get; private set; }
        public bool TargetFound { get; private set; }
        public bool OnlyOneTarget { get; private set; }
        public GameObject SelectedTarget { get; set; }
        public List<Character_InBattle> FinalTargets { get; private set; }

        public void SetFinalTargets(Battle_Action executedAction)
        {
            if (executedAction == null) return;

            int actionScale = executedAction.Scale;

            FinalTargets = new List<Character_InBattle>()
            {
                SelectedTarget.GetComponent<Character_InBattle>()
            };

            if (actionScale == 0) return;

            Character_InBattle selectedTarget = SelectedTarget.GetComponent<Character_InBattle>();

            for (int i = 0; i < searchedSide.Count; i++)
            {
                if (searchedSide[i].Dead == true) continue;

                int x = Mathf.Abs(searchedSide[i].StandingTileX - selectedTarget.StandingTileX);
                int z = Mathf.Abs(searchedSide[i].StandingTileZ - selectedTarget.StandingTileZ);

                if ((x + z) == 0) continue;

                if ((x + z) <= actionScale) FinalTargets.Add(searchedSide[i]);
            }
        }

        public void Update()
        {
            SpinTargetMarks();
        }

        public void MarkAvailableTargets()
        {
            List<GameObject> targetMarks = objectManager.TargetMarks;

            for (int i = 0; i < AvailableTargets.Count; i++)
            {
                targetMarks[i].gameObject.SetActive(true);

                targetMarks[i].gameObject.transform.position = AvailableTargets[i].gameObject.transform.position;
            }
        }

        public void RemoveMarks()
        {
            objectManager.DisableTargetMarks();
        }

        public void SetAvailableTargets(Battle_Action executedAction)
        {
            searchedSide = null;

            TargetFound = false;
            OnlyOneTarget = false;
            SelectedTarget = null;

            AvailableTargets = new List<GameObject>();

            if (executedAction.ActionType == actionTypeSupport) searchedSide = turnController.SameSide;
            else searchedSide = turnController.OppositeSide;

            // search targets
            Character_InBattle currentTurnCharacter = turnController.CurrentTurnCharacter;

            for (int i = 0; i < searchedSide.Count; i++)
            {
                if (searchedSide[i].Dead == true) continue;

                int x = Mathf.Abs(searchedSide[i].StandingTileX - currentTurnCharacter.StandingTileX);
                int z = Mathf.Abs(searchedSide[i].StandingTileZ - currentTurnCharacter.StandingTileZ);

                if ((x + z) > executedAction.Range) continue;

                AvailableTargets.Add(searchedSide[i].gameObject);
            }

            TargetFound = (AvailableTargets.Count > 0) ? true : false;
            OnlyOneTarget = (AvailableTargets.Count == 1) ? true : false;
        }

        private void SpinTargetMarks()
        {
            for (int i = 0; i < objectManager.TargetMarks.Count; i++)
            {
                GameObject targetMark = objectManager.TargetMarks[i];

                targetMark.gameObject.transform.Rotate(0, 256.0f * Time.deltaTime, 0);
            }
        }
    }
}
