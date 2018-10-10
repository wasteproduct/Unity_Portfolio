using UnityEngine;
using Character;
using MapDataSet;
using System.Collections.Generic;

namespace Player
{
    public class Player_DungeonSettings : MonoBehaviour
    {
        public GameObject tileMap;
        public GameObject dungeonPlayManager;
        public GameObject testCharacter;

        public Player_Team playerTeam;
        public Character_Database characterDatabase;
        public Variable_Int currentTileX;
        public Variable_Int currentTileZ;

        private Map_Data mapData;

        // Use this for initialization
        void Start()
        {
            mapData = tileMap.GetComponent<Map_Main>().MapData;

            currentTileX.value = mapData.StartingTile.X;
            currentTileZ.value = mapData.StartingTile.Z;

            List<GameObject> characters = new List<GameObject>();

            GameObject captain = Instantiate<GameObject>(testCharacter, new Vector3((float)currentTileX.value, 0.0f, (float)currentTileZ.value), Quaternion.identity);
            captain.GetComponent<Character_InDungeon>().Initialize(true, mapData, dungeonPlayManager.GetComponent<Manager_DungeonPlay>(), null);
            characters.Add(captain);

            GameObject frontOne = captain;

            for (int i = 0; i < 2; i++)
            {
                int offset = i + 1;

                GameObject newFellow = Instantiate<GameObject>(testCharacter, new Vector3((float)currentTileX.value, 0.0f, (float)(currentTileZ.value - offset)), Quaternion.identity);
                newFellow.GetComponent<Character_InDungeon>().Initialize(false, mapData, dungeonPlayManager.GetComponent<Manager_DungeonPlay>(), frontOne);
                characters.Add(newFellow);

                frontOne = newFellow;
            }

            this.gameObject.GetComponent<Player_Move>().Initialize(characters);

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
