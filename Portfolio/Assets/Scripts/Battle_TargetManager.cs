using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Target Manager", order = 1)]
    public class Battle_TargetManager : ScriptableObject
    {
        public Battle_TurnController turnController;
        public Variable_Bool choosingTarget;

        public List<GameObject> PotentialTargets { get; private set; }
        public bool TargetFound { get; private set; }
        public bool OnlyOneTarget { get; private set; }
        public GameObject Target { get; set; }

        public void HighlightTargets(bool flag)
        {
            for (int i = 0; i < PotentialTargets.Count; i++)
            {
                PotentialTargets[i].GetComponent<Character_InBattle>().HighlightAsTarget(flag);
            }
        }

        public void SearchTargets()
        {
            choosingTarget.flag = true;

            TargetFound = false;
            OnlyOneTarget = false;
            Target = null;

            PotentialTargets = new List<GameObject>();

            Character_InBattle currentTurnCharacter = turnController.CurrentTurnCharacter;
            for (int i = 0; i < turnController.OppositeSide.Count; i++)
            {
                Character_InBattle oppositeCharacter = turnController.OppositeSide[i];

                int xDistance = Mathf.Abs(oppositeCharacter.StandingTileX - currentTurnCharacter.StandingTileX);
                int zDistance = Mathf.Abs(oppositeCharacter.StandingTileZ - currentTurnCharacter.StandingTileZ);

                if (xDistance + zDistance > currentTurnCharacter.AttackRange) continue;

                PotentialTargets.Add(turnController.OppositeSide[i].gameObject);
            }

            TargetFound = (PotentialTargets.Count > 0) ? true : false;
            OnlyOneTarget = (PotentialTargets.Count == 1) ? true : false;
        }






        // failure
        //public GameObject Enemy_ChooseTarget(Character_InBattle currentTurnCharacter)
        //{
            
        //}

        public void CountTargetsInAttackRange(Character_InBattle currentTurnCharacter)
        {
            //Targets = new List<GameObject>();

            //for (int i = 0; i < turnController.OppositeSide.Count; i++)
            //{
            //    if ((Mathf.Abs(turnController.OppositeSide[i].StandingTileX - currentTurnCharacter.StandingTileX) + Mathf.Abs(turnController.OppositeSide[i].StandingTileZ - currentTurnCharacter.StandingTileZ)) <= currentTurnCharacter.AttackRange) Targets.Add(turnController.OppositeSide[i].gameObject);
            //}

            //// temporary
            ////if (turnController.enemyTurn.flag == true) return;

            //for (int i = 0; i < Targets.Count; i++)
            //{
            //    Targets[i].GetComponent<Character_InBattle>().HighlightAsTarget(true);
            //}
        }
    }
}
