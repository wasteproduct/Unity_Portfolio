using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Target Manager", order = 1)]
    public class Battle_TargetManager : ScriptableObject
    {
        public List<GameObject> Targets { get; private set; }

        public bool CountTargetsInAttackRange(int x, int z, Character_InBattle currentTurnCharacter, List<Character_InBattle> oppositeSide)
        {
            Targets = new List<GameObject>();

            for (int i = 0; i < oppositeSide.Count; i++)
            {
                if ((Mathf.Abs(oppositeSide[i].StandingTileX - x) + Mathf.Abs(oppositeSide[i].StandingTileZ - z)) <= currentTurnCharacter.AttackRange) Targets.Add(oppositeSide[i].gameObject);
            }

            if (Targets.Count > 0) return true;

            return false;
        }
    }
}
