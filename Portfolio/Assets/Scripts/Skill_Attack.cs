﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill
{
    [CreateAssetMenu(fileName = "", menuName = "Skill/Attack", order = 1)]
    public class Skill_Attack : Skill_Base
    {
        public float Damage { get { return damage; } }
        public int Range { get { return range; } }
        public float SplashedDamageRate { get { return splashedDamageRate; } }
        //public skill effect

        [SerializeField]
        private float damage;
        [SerializeField]
        private int range;
        [SerializeField]
        private float splashedDamageRate;
        //public skill effect

        public override void SetTarget(GameObject target)
        {
            Target = target;
        }
    }
}
