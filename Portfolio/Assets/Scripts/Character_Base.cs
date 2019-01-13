using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "", menuName = "Character/Base", order = 1)]
    public class Character_Base : ScriptableObject
    {
        [SerializeField]
        private Sprite portrait;
        [SerializeField]
        private GameObject displayedModel;
        [SerializeField]
        private string characterName;
        [SerializeField]
        private int typeID;
        [SerializeField]
        private int strength;
        [SerializeField]
        private int agility;
        [SerializeField]
        private int intelligence;

        public Sprite Portrait { get { return portrait; } }
        public GameObject DisplayedModel { get { return displayedModel; } }
        public string CharacterName { get { return characterName; } }
        public int TypeID { get { return typeID; } }
        public int Strength { get { return strength; } }
        public int Agility { get { return agility; } }
        public int Intelligence { get { return intelligence; } }

        public GameObject InstantiatedModel { get; set; }

        //[SerializeField]
        //private string skill1;
        //public string Skill1 { get { return skill1; } }

        //public void CopyData(Editor_CharacterData copiedBase)
        //{
        //    Name = copiedBase.Name;
        //    TypeID = copiedBase.TypeID;
        //    Strength = copiedBase.Strength;
        //    Agility = copiedBase.Agility;
        //    Intelligence = copiedBase.Intelligence;

        //    skill1 = copiedBase.Skill1;
        //}
    }
}
