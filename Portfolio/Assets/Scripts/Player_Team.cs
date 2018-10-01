using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Player
{
    [CreateAssetMenu(fileName = "", menuName = "Player/Team", order = 1)]
    public class Player_Team : ScriptableObject
    {
        public Character_Base captain;
        public Character_Base[] teamFellow;
    }
}
