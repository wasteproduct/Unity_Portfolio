﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using MapDataSet;

public class Character_ExploreCaptain : Character_Explore
{
    public Event_Click clickEvent;
    public Calculation_AStar aStar;
    public Manager_CommonFeatures commonFeatures;
    public Calculation_Move moveController;

    public Variable_Int currentTileX;
    public Variable_Int currentTileZ;
    public Variable_Int mouseOnTileX;
    public Variable_Int mouseOnTileZ;
    //public Variable_Bool moving;
    
    private Map_Data mapData;

    public void Initialize(Map_Data MapData, Manager_DungeonPlay dungeonPlayManager)
    {
        mapData = MapData;
        //dungeonPlay = dungeonPlayManager;
    }

    // Update is called once per frame
    void Update()
    {
        currentTileX.value = (int)(this.gameObject.transform.position.x + .5f);
        currentTileZ.value = (int)(this.gameObject.transform.position.z + .5f);
    }

    public override void StartMoving()
    {
        if (clickEvent.pathFound == false) return;
        //print(aStar.FinalTrack.Count);

        //if ((aStar.FinalTrack.Count < 2) && (clickEvent.doorTile == true))
        //{
        //    mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value].OpenDoor();
        //    return;
        //}
        if (aStar.FinalTrack.Count <= 1)
        {
            print("FUCK");
            return;
        }

        StartCoroutine(Move(clickEvent.doorTile));
    }

    private IEnumerator Move(bool doorTile)
    {
        int targetIndex = 1;
        float elapsedTime = 0.0f;

        while (true)
        {
            if (elapsedTime >= moveController.ElapsedTimeLimit)
            {
                targetIndex++;
                elapsedTime = 0.0f;

                if (targetIndex == aStar.FinalTrack.Count)
                {
                    moveController.moving = false;
                    break;
                }
            }

            elapsedTime += Time.deltaTime;
            this.gameObject.transform.position = moveController.LerpPosition(aStar.FinalTrack[targetIndex - 1], aStar.FinalTrack[targetIndex], elapsedTime);

            yield return null;
        }
        //int startX = aStar.FinalTrack[trackIndex].X;
        //int startZ = aStar.FinalTrack[trackIndex].Z;
        //int endX = aStar.FinalTrack[trackIndex + 1].X;
        //int endZ = aStar.FinalTrack[trackIndex + 1].Z;
        //Quaternion startingRotation = this.gameObject.transform.rotation;
        //float elapsedTime = 0.0f;

        //while (true)
        //{
        //    if (elapsedTime >= elapsedTimeLimit)
        //    {
        //        elapsedTime = 0.0f;

        //        if (trackIndex >= aStar.FinalTrack.Count - 2)
        //        {
        //            if (doorTile == true) mapData.TileData[doorX, doorZ].OpenDoor();

        //            moving.flag = false;

        //            if (clickEvent.intoEnemyZone == true)
        //            {
        //                dungeonPlay.StartBattle();
        //                Destroy(clickEvent.destroyedObject.gameObject);
        //                clickEvent.intoEnemyZone = false;
        //            }

        //            break;
        //        }

        //        trackIndex++;

        //        startingPosition = new Vector3((float)aStar.FinalTrack[trackIndex].X, 0.0f, (float)aStar.FinalTrack[trackIndex].Z);
        //        destination = new Vector3((float)aStar.FinalTrack[trackIndex + 1].X, 0.0f, (float)aStar.FinalTrack[trackIndex + 1].Z);
        //        startX = aStar.FinalTrack[trackIndex].X;
        //        startZ = aStar.FinalTrack[trackIndex].Z;
        //        endX = aStar.FinalTrack[trackIndex + 1].X;
        //        endZ = aStar.FinalTrack[trackIndex + 1].Z;
        //        startingRotation = this.gameObject.transform.rotation;

        //        this.gameObject.GetComponent<Character_InDungeon>().SetPreviousPosition(startingPosition);
        //    }

        //    elapsedTime += Time.deltaTime;
        //    float lerpTime = elapsedTime / elapsedTimeLimit;
        //    this.gameObject.transform.position = Vector3.Lerp(startingPosition, destination, lerpTime);
        //    this.gameObject.transform.rotation = commonFeatures.rotationCalculator.LerpRotation(startX, startZ, endX, endZ, startingRotation, lerpTime);

        //    yield return null;
        //}
    }
}
