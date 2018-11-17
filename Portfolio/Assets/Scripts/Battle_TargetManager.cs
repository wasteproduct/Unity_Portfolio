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
        public Variable_Bool choosingTarget;

        public List<GameObject> PotentialTargets { get; private set; }
        public bool TargetFound { get; private set; }
        public bool OnlyOneTarget { get; private set; }
        public GameObject SelectedTarget { get; set; }
        public List<Character_InBattle> FinalTargets { get; private set; }

        public void SetFinalTargets(int actionScale)
        {
            FinalTargets = new List<Character_InBattle>()
            {
                SelectedTarget.GetComponent<Character_InBattle>()
            };

            if (actionScale == 0) return;

            Character_InBattle selectedTarget = SelectedTarget.GetComponent<Character_InBattle>();
            List<Character_InBattle> potentialTargets = turnController.OppositeSide;

            for (int i = 0; i < potentialTargets.Count; i++)
            {
                if (potentialTargets[i].Dead == true) continue;

                int x = Mathf.Abs(potentialTargets[i].StandingTileX - selectedTarget.StandingTileX);
                int z = Mathf.Abs(potentialTargets[i].StandingTileZ - selectedTarget.StandingTileZ);

                if ((x + z) == 0) continue;

                if ((x + z) <= actionScale) FinalTargets.Add(potentialTargets[i]);
            }
        }

        public void Update()
        {
            SpinTargetMarks();
        }

        public void MarkAvailableTargets()
        {
            List<GameObject> targetMarks = objectManager.TargetMarks;

            for (int i = 0; i < PotentialTargets.Count; i++)
            {
                targetMarks[i].gameObject.SetActive(true);

                targetMarks[i].gameObject.transform.position = PotentialTargets[i].gameObject.transform.position;
            }
        }

        public void RemoveMarks()
        {
            objectManager.DisableTargetMarks();
        }

        public void SearchTargets()
        {
            // temporary
            if (turnController.CurrentTurnCharacter.actionAttack == null) return;

            choosingTarget.flag = true;

            TargetFound = false;
            OnlyOneTarget = false;
            SelectedTarget = null;

            PotentialTargets = new List<GameObject>();

            Character_InBattle currentTurnCharacter = turnController.CurrentTurnCharacter;
            for (int i = 0; i < turnController.OppositeSide.Count; i++)
            {
                if (turnController.OppositeSide[i].Dead == true) continue;

                Character_InBattle oppositeCharacter = turnController.OppositeSide[i];

                int xDistance = Mathf.Abs(oppositeCharacter.StandingTileX - currentTurnCharacter.StandingTileX);
                int zDistance = Mathf.Abs(oppositeCharacter.StandingTileZ - currentTurnCharacter.StandingTileZ);

                if (xDistance + zDistance > currentTurnCharacter.actionAttack.Range) continue;

                PotentialTargets.Add(turnController.OppositeSide[i].gameObject);
            }

            TargetFound = (PotentialTargets.Count > 0) ? true : false;
            OnlyOneTarget = (PotentialTargets.Count == 1) ? true : false;
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
