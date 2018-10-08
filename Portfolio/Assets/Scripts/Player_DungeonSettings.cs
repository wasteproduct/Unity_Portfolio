using UnityEngine;
using Character;

namespace Player
{
    public class Player_DungeonSettings : MonoBehaviour
    {
        public Player_Team playerTeam;
        public Character_Database characterDatabase;
        public Variable_Int currentTileX;
        public Variable_Int currentTileZ;

        // Use this for initialization
        void Start()
        {
            //for (int i = 0; i < characterDatabase.Models.Count; i++)
            //{
            //    if (characterDatabase.Models[i].typeID == playerTeam.captain.TypeID)
            //    {
            //        Instantiate<GameObject>(characterDatabase.Models[i].modelPrefab, this.gameObject.transform);
            //        break;
            //    }
            //}

            //int startingZ = currentTileZ.value;
            //for (int i = 0; i < playerTeam.teamFellow.Length; i++)
            //{
            //    for (int j = 0; j < characterDatabase.Models.Count; j++)
            //    {
            //        if (playerTeam.teamFellow[i] == null) continue;

            //        if (playerTeam.teamFellow[i].TypeID == characterDatabase.Models[j].typeID)
            //        {
            //            startingZ -= 2;
            //            Instantiate<GameObject>(characterDatabase.Models[j].modelPrefab, new Vector3((float)currentTileX.value, 0.0f, (float)startingZ), this.gameObject.transform.rotation, this.gameObject.transform);
            //        }
            //    }
            //}
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
