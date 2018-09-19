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

        public int Strength { get { return strength; } }
        public int Agility { get { return agility; } }
        public int Intelligence { get { return intelligence; } }
        //public List<Skill_Base> Skills { get { return skills; } }
        public Character_Type Type { get { return type; } }
        public string CharacterName { get { return characterName; } }
    }
}
