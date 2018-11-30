using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Attack Action Impact/Soldier Attack", order = 1)]
    public class Battle_ImpactSoldierAttack : Battle_ImpactBase
    {
        public Battle_TargetManager targetManager;
        public Calculation_DamageAmount damageCalculator;
        public Battle_ActionManager actionManager;
        public Battle_TurnController turnController;

        public override void Run()
        {
            List<Character_InBattle> finalTargets = targetManager.FinalTargets;
            float appliedDamage = damageCalculator.CalculateDamageAmount(actionManager.ExecutedAction.Power, turnController.CurrentTurnCharacter.AppliedDebuffs);
            float splashedAmountRate = actionManager.ExecutedAction.SplashedPowerRate;

            finalTargets[0].Damage(appliedDamage);
            for (int i = 1; i < finalTargets.Count; i++)
            {
                float splashedDamage = appliedDamage * splashedAmountRate;
                finalTargets[i].Damage(splashedDamage);
            }
        }
    }
}
