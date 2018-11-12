using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill
{
    public abstract class Skill_Base : ScriptableObject
    {
        [SerializeField]
        protected int range;

        public int Range { get { return range; } }
        public GameObject Target { get; protected set; }

        public abstract void SetTarget(GameObject target);
    }
}
