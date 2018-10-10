using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_InDungeon : MonoBehaviour
{
    private bool captain;

    public Vector3 PreviousPosition { get; private set; }

    public void SetPreviousPosition(Vector3 newPosition) { PreviousPosition = newPosition; }

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
            //this.gameObject.GetComponent<Character_ExploreCaptain>().Initialize(MapData, dungeonPlayManager);
        }
        else
        {
            this.gameObject.GetComponent<Character_ExploreFellow>().enabled = true;
            this.gameObject.GetComponent<Character_ExploreFellow>().Initialize(frontOne);
        }

        PreviousPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
