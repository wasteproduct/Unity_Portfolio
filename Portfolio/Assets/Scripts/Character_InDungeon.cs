using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_InDungeon : MonoBehaviour
{
    private bool captain;

    public void StartMoving()
    {
        if (captain == true) this.gameObject.GetComponent<Character_ExploreCaptain>().StartMoving();
        else this.gameObject.GetComponent<Character_ExploreFellow>().StartMoving();
    }

    public void Initialize(bool flagCaptain, MapDataSet.Map_Data MapData, Manager_DungeonPlay dungeonPlayManager, GameObject frontOne)
    {
        captain = flagCaptain;

        this.gameObject.GetComponent<EventListener_Click>().enabled = true;

        if (captain == true)
        {
            this.gameObject.GetComponent<Character_ExploreCaptain>().enabled = true;
            this.gameObject.GetComponent<Character_ExploreCaptain>().Initialize(frontOne);
        }
        else
        {
            this.gameObject.GetComponent<Character_ExploreFellow>().enabled = true;
            this.gameObject.GetComponent<Character_ExploreFellow>().Initialize(frontOne);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
