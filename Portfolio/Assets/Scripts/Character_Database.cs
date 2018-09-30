using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "", menuName = "Character/Database", order = 1)]
    public class Character_Database : ScriptableObject
    {
        public Character_Base baseSoldier;
        public Character_Base baseTank;

        [SerializeField]
        List<Character_Portraits> portraits = new List<Character_Portraits>();

        [SerializeField]
        List<Character_Models> models = new List<Character_Models>();

        public List<Character_Portraits> Portraits { get { return portraits; } }
        public List<Character_Models> Models { get { return models; } }
    }
}
