using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "", menuName = "Character/Base", order = 1)]
    public class Character_Base : ScriptableObject
    {
        public GameObject model;
        public int strength;
        public int agility;
        public int intelligence;
        //public List<Skill_Base> skills;
        public Character_Type type;
        public string characterName;
    }
}
