using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Battle/Turn Controller", order = 1)]
    public class Battle_TurnController : ScriptableObject
    {
        private int controllingNumber = 0;

        public void Initialize()
        {
            controllingNumber = 0;
        }

        //여기
    }
}
