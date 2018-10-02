using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "", menuName = "Character/Database", order = 1)]
    public class Character_Database : ScriptableObject
    {
        [SerializeField]
        List<Character_Base> bases = new List<Character_Base>();

        [SerializeField]
        List<Character_Portraits> portraits = new List<Character_Portraits>();

        [SerializeField]
        List<Character_Models> models = new List<Character_Models>();

        public List<Character_Base> Bases { get { return bases; } }
        public List<Character_Portraits> Portraits { get { return portraits; } }
        public List<Character_Models> Models { get { return models; } }
    }
}
