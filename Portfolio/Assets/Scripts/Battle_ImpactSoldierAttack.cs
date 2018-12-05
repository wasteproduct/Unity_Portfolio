using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Attack Action Impact/Soldier Attack", order = 1)]
    public class Battle_ImpactSoldierAttack : Battle_ImpactBase
    {
        public Calculation_ApplyDamage damageApplier;

        public override void Run()
        {
            damageApplier.ApplyDamage();
        }
    }
}
