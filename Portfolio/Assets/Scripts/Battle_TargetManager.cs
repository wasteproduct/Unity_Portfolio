using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Target Manager", order = 1)]
    public class Battle_TargetManager : ScriptableObject
    {
        public Battle_TurnController turnController;

        public List<GameObject> Targets;

        public void CountTargetsInAttackRange(Character_InBattle currentTurnCharacter)
        {
            Targets = new List<GameObject>();

            for (int i = 0; i < turnController.OppositeSide.Count; i++)
            {
                if ((Mathf.Abs(turnController.OppositeSide[i].StandingTileX - currentTurnCharacter.StandingTileX) + Mathf.Abs(turnController.OppositeSide[i].StandingTileZ - currentTurnCharacter.StandingTileZ)) <= currentTurnCharacter.AttackRange) Targets.Add(turnController.OppositeSide[i].gameObject);
            }

            for (int i = 0; i < Targets.Count; i++)
            {
                Targets[i].GetComponent<Character_InBattle>().HighlightAsTarget(true);
            }
        }
    }
}
