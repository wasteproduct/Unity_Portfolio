using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "", menuName = "Character/Portrait", order = 1)]
    public class Character_Portraits : ScriptableObject
    {
        public Sprite image;
        public int typeID;
    }
}
