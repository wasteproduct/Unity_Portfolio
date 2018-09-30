using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "", menuName = "Character/Model", order = 1)]
    public class Character_Models : ScriptableObject
    {
        public GameObject modelPrefab;
        public int typeID;
    }
}
