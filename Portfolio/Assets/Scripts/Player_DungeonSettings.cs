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
            captain.GetComponent<Character_InDungeon>().Initialize(true, mapData, dungeonPlayManager.GetComponent<Manager_DungeonPlay>());
            characters.Add(captain);

            for (int i = 0; i < 2; i++)
            {
                int offset = i + 1;

                GameObject newFellow = Instantiate<GameObject>(testCharacter, new Vector3((float)currentTileX.value, 0.0f, (float)(currentTileZ.value - offset)), Quaternion.identity);
                newFellow.GetComponent<Character_InDungeon>().Initialize(false, mapData, dungeonPlayManager.GetComponent<Manager_DungeonPlay>());
                characters.Add(newFellow);
            }

            this.gameObject.GetComponent<Player_Move>().Initialize(characters);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
