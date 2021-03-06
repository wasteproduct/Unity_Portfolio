﻿using UnityEngine;
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
        public Variable_GameObject objectCaptain;

        private Map_Data mapData;

        public List<GameObject> PlayerCharacters { get; private set; }

        // Use this for initialization
        void Start()
        {
            mapData = tileMap.GetComponent<Map_Main>().MapData;

            currentTileX.value = mapData.StartingTile.X;
            currentTileZ.value = mapData.StartingTile.Z;

            PlayerCharacters = new List<GameObject>();

            GameObject captain = null;
            for (int i = 0; i < characterDatabase.Models.Count; i++)
            {
                if (characterDatabase.Models[i].typeID == playerTeam.Captain.TypeID)
                {
                    captain = Instantiate(characterDatabase.Models[i].modelPrefab, new Vector3(currentTileX.value, 0.0f, currentTileZ.value), Quaternion.identity);
                    break;
                }
            }

            if (captain == null)
            {
                print("Null captain.");
                return;
            }

            captain.GetComponent<Character_InDungeon>().Initialize(true, mapData, dungeonPlayManager.GetComponent<Manager_DungeonPlay>());
            captain.GetComponent<Character_InBattle>().Initialize(mapData, false);
            captain.GetComponent<Character_StateManager>().Initialize();
            captain.GetComponent<FogOfWar_Revealer>().RegisterRevealer();
            PlayerCharacters.Add(captain);

            int offset = -1;
            for (int i = 0; i < playerTeam.TeamFellows.Length; i++)
            {
                if (playerTeam.TeamFellows[i] == null) continue;

                for (int j = 0; j < characterDatabase.Models.Count; j++)
                {
                    if (playerTeam.TeamFellows[i].TypeID == characterDatabase.Models[j].typeID)
                    {
                        GameObject newFellow = Instantiate(characterDatabase.Models[j].modelPrefab, new Vector3(currentTileX.value, 0.0f, currentTileZ.value + offset), Quaternion.identity);
                        newFellow.GetComponent<Character_InDungeon>().Initialize(false, mapData, dungeonPlayManager.GetComponent<Manager_DungeonPlay>());
                        newFellow.GetComponent<Character_InBattle>().Initialize(mapData, false);
                        newFellow.GetComponent<Character_StateManager>().Initialize();
                        PlayerCharacters.Add(newFellow);

                        offset--;
                    }
                }
            }

            gameObject.GetComponent<Player_Move>().Initialize(PlayerCharacters);

            Camera.main.GetComponent<Camera_Movement>().SetFocus(captain.gameObject);

            objectCaptain.value = captain;

            GetComponent<Player_InDungeonManager>().Initialize();

            GetComponent<Player_Navigator>().Initialize(mapData.Rooms);
        }
    }
}
