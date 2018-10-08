﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_InDungeon : MonoBehaviour
{
    private bool captain;

    public void StartMoving()
    {
        if (captain == true) this.gameObject.GetComponent<Character_ExploreCaptain>().StartMoving();
    }

    public void Initialize(bool flagCaptain, MapDataSet.Map_Data MapData, Manager_DungeonPlay dungeonPlayManager)
    {
        captain = flagCaptain;

        if (captain == true)
        {
            this.gameObject.GetComponent<Character_ExploreCaptain>().enabled = true;
            this.gameObject.GetComponent<Character_ExploreCaptain>().Initialize(MapData, dungeonPlayManager);

            this.gameObject.GetComponent<EventListener_Click>().enabled = true;
        }
        else this.gameObject.GetComponent<Character_ExploreFellow>().enabled = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
