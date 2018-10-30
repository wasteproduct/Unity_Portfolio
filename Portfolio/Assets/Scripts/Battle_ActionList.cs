using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Action List", order = 1)]
    public class Battle_ActionList : ScriptableObject
    {
        public Battle_Action actionAttack;
        public Battle_Action actionSkill1;
    }
}
