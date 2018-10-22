﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Target Manager", order = 1)]
    public class Battle_TargetManager : ScriptableObject
    {
        public Battle_TurnController turnController;

        public List<GameObject> Targets;

        public void SearchTargets()
        {
            Targets = new List<GameObject>();

            
        }






        // failure
        public GameObject Enemy_ChooseTarget(Character_InBattle currentTurnCharacter)
        {
            // 거리에 따른
            int closestDistance = 99999999;
            List<Character_InBattle> oppositeSide = turnController.OppositeSide;
            GameObject result = null;
            for (int i = 0; i < oppositeSide.Count; i++)
            {
                int distance = Mathf.Abs(oppositeSide[i].StandingTileX - currentTurnCharacter.StandingTileX) + Mathf.Abs(oppositeSide[i].StandingTileZ - currentTurnCharacter.StandingTileZ);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    result = oppositeSide[i].gameObject;
                }
            }

            // 타입에 따른

            // 체력에 따른

            return result;
        }

        public void CountTargetsInAttackRange(Character_InBattle currentTurnCharacter)
        {
            Targets = new List<GameObject>();

            for (int i = 0; i < turnController.OppositeSide.Count; i++)
            {
                if ((Mathf.Abs(turnController.OppositeSide[i].StandingTileX - currentTurnCharacter.StandingTileX) + Mathf.Abs(turnController.OppositeSide[i].StandingTileZ - currentTurnCharacter.StandingTileZ)) <= currentTurnCharacter.AttackRange) Targets.Add(turnController.OppositeSide[i].gameObject);
            }

            // temporary
            if (turnController.enemyTurn.flag == true) return;

            for (int i = 0; i < Targets.Count; i++)
            {
                Targets[i].GetComponent<Character_InBattle>().HighlightAsTarget(true);
            }
        }
    }
}
