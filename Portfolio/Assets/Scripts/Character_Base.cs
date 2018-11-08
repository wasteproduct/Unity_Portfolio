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

        [SerializeField]
        private string skill1;

        public string Skill1 { get { return skill1; } }
        //public List<Skill_Base> skills;
        // Make skills data as json file
        // Load data when characters instantiated

        public void CopyData(Editor_CharacterData copiedBase)
        {
            Name = copiedBase.Name;
            TypeID = copiedBase.TypeID;
            Strength = copiedBase.Strength;
            Agility = copiedBase.Agility;
            Intelligence = copiedBase.Intelligence;

            skill1 = copiedBase.Skill1;
        }
    }
}
