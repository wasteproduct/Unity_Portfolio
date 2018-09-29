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

        public GameObject modelSoldier;
        public GameObject modelTank;

        public Sprite portraitSoldier;
        public Sprite portraitTank;
    }
}
