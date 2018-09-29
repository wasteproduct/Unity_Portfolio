using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Character
{
    [CreateAssetMenu(fileName = "", menuName = "Character/Base", order = 1)]
    public class Character_Base : ScriptableObject
    {
        public string Name;
        public int TypeID;
        public int Strength;
        public int Agility;
        public int Intelligence;
        //public List<Skill_Base> skills;

        //public void CopyData(Character_Base copiedBase)
        //{
        //    this.characterName = copiedBase.characterName;
        //    this.typeID = copiedBase.typeID;
        //    this.strength = copiedBase.strength;
        //    this.agility = copiedBase.agility;
        //    this.intelligence = copiedBase.intelligence;
        //}

        public void CopyData(Editor_CharacterData copiedBase)
        {
            this.Name = copiedBase.Name;
            this.TypeID = copiedBase.TypeID;
            this.Strength = copiedBase.Strength;
            this.Agility = copiedBase.Agility;
            this.Intelligence = copiedBase.Intelligence;
        }
    }
}
