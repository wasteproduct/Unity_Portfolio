using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using MapDataSet;

namespace Player
{
    [CreateAssetMenu(fileName = "", menuName = "Player/Team", order = 1)]
    public class Player_Team : ScriptableObject
    {
        public Variable_Int currentTileX;
        public Variable_Int currentTileZ;

        public Character_Base captain;
        public Character_Base[] teamFellow;
    }
}
