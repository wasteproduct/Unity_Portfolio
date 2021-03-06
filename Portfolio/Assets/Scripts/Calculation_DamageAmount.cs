﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Calculation/Damage", order = 1)]
    public class Calculation_DamageAmount : ScriptableObject
    {
        public Debuff_Type debuffParameter;

        public float CalculateDamageAmount(float initialAmount, List<Debuff> appliedDebuffs)
        {
            float result = initialAmount;

            for (int i = 0; i < appliedDebuffs.Count; i++)
            {
                if (appliedDebuffs[i].DebuffType != debuffParameter) continue;

                result -= (result * appliedDebuffs[i].ReductionRate);
            }

            return result;
        }
    }
}
