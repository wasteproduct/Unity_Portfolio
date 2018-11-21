using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public abstract class Debuff : ScriptableObject
    {
        public Battle_TargetManager targetManager;
        public Debuff_Type type;
    }
}
