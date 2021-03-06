﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_InDungeon : MonoBehaviour
{
    private bool captain;

    public Character_Explore MoveController { get; private set; }

    public void Initialize(bool flagCaptain, MapDataSet.Map_Data mapData, Manager_DungeonPlay dungeonPlayManager)
    {
        captain = flagCaptain;

        if (captain == true)
        {
            gameObject.GetComponent<Character_ExploreCaptain>().enabled = true;
            gameObject.GetComponent<Character_ExploreCaptain>().Initialize(mapData);
            MoveController = gameObject.GetComponent<Character_ExploreCaptain>();
        }
        else
        {
            gameObject.GetComponent<Character_ExploreFellow>().enabled = true;
            gameObject.GetComponent<Character_ExploreFellow>().Initialize(mapData);
            MoveController = gameObject.GetComponent<Character_ExploreFellow>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
