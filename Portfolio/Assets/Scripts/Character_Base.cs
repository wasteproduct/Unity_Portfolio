using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "", menuName = "Character/Base", order = 1)]
    public class Character_Base : ScriptableObject
    {
        public string characterName;
        public Sprite portrait;
        public GameObject model;
        public int typeID;
        public int strength;
        public int agility;
        public int intelligence;
        //public List<Skill_Base> skills;

        public void CopyData(Character_Base copiedBase)
        {
            this.characterName = copiedBase.characterName;
            this.portrait = copiedBase.portrait;
            this.model = copiedBase.model;
            this.typeID = copiedBase.typeID;
            this.strength = copiedBase.strength;
            this.agility = copiedBase.agility;
            this.intelligence = copiedBase.intelligence;
        }
    }
}
