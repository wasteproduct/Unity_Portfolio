using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_InDungeon : MonoBehaviour
{
    private bool captain;

    public Character_Explore MoveController { get; private set; }

    public void Initialize(bool flagCaptain, MapDataSet.Map_Data MapData, Manager_DungeonPlay dungeonPlayManager)
    {
        captain = flagCaptain;

        if (captain == true)
        {
            this.gameObject.GetComponent<Character_ExploreCaptain>().enabled = true;
            this.gameObject.GetComponent<Character_ExploreCaptain>().Initialize(MapData);
            this.MoveController = this.gameObject.GetComponent<Character_ExploreCaptain>();
        }
        else
        {
            this.gameObject.GetComponent<Character_ExploreFellow>().enabled = true;
            this.gameObject.GetComponent<Character_ExploreFellow>().Initialize(MapData);
            this.MoveController = this.gameObject.GetComponent<Character_ExploreFellow>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
