using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill
{
    public abstract class Skill_Base : ScriptableObject
    {
        public GameObject Target { get; protected set; }

        public abstract void SetTarget(GameObject target);
    }
}
