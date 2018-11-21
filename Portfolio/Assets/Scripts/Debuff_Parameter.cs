using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Debuff/Parameter", order = 1)]
    public class Debuff_Parameter : Debuff
    {
        [SerializeField]
        private float reductionRate;

        public float ReductionRate { get { return reductionRate; } }
    }
}
