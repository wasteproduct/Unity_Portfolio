﻿using UnityEngine;
using MapDataSet;
using TileDataSet;
using AStar;
using Battle;

public class Cursor : MonoBehaviour
{
    public GameObject tileMap;
    public GameObject battleManager;

    public Material defaultColor;
    public Material green;
    public Material red;
    public Material yellow;

    public Event_Click clickEvent;

    public Variable_Int mouseOnTileX;
    public Variable_Int mouseOnTileZ;
    public Calculation_AStar aStar;
    public Variable_Int currentTileX;
    public Variable_Int currentTileZ;
    public Calculation_Move moveController;
    public Manager_Layers layers;
    public Manager_CommonFeatures commonFeatures;
    public Manager_DungeonPhase phaseManager;
    public Variable_Bool choosingTarget;

    private Map_Data mapData;
    private bool leftClicked;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Renderer>().material = defaultColor;

        mapData = tileMap.GetComponent<Map_Main>().MapData;

        leftClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        ResetDoorColors();

        if (choosingTarget.flag == true)
        {
            this.transform.position = Vector3.zero;
            return;
        }

        LeftClick();

        this.transform.position = new Vector3((float)mouseOnTileX.value, 0.0f, (float)mouseOnTileZ.value);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100.0f) == true)
        {
            SetMouseOnTile(hitInfo);

            HighlightDoor();

            return;
        }

        mouseOnTileX.value = commonFeatures.invalidIndex;
        mouseOnTileZ.value = commonFeatures.invalidIndex;
    }

    private void SetMouseOnTile(RaycastHit hitInfo)
    {
        if ((1 << hitInfo.collider.gameObject.layer == (int)layers.TileMap) || (1 << hitInfo.collider.gameObject.layer == (int)layers.EnemyZone))
        {
            mouseOnTileX.value = (int)(hitInfo.point.x + .5f);
            mouseOnTileZ.value = (int)(hitInfo.point.z + .5f);

            SetClickedCursorMaterial();

            return;
        }
    }

    private void LeftClick()
    {
        if (moveController.moving == true) return;

        if (Input.GetMouseButtonDown(0))
        {
            if ((mouseOnTileX.value == commonFeatures.invalidIndex) || (mouseOnTileZ.value == commonFeatures.invalidIndex)) return;

            leftClicked = true;
        }

        TracePath();

        if (Input.GetMouseButtonUp(0))
        {
            if (leftClicked == false) return;

            clickEvent.destinationTile = mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value];

            //Explore_CheckIntoEnemyZone();

            this.GetComponent<Renderer>().material = defaultColor;
            leftClicked = false;

            clickEvent.Run();
        }
    }

    //private void Explore_CheckIntoEnemyZone()
    //{
    //    if (phaseManager.CurrentPhase != phaseManager.Phase_Explore) return;

    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hitInfo;
    //    if (Physics.Raycast(ray, out hitInfo, 100.0f) == true)
    //    {
    //        if (1 << hitInfo.collider.gameObject.layer == (int)layers.EnemyZone)
    //        {
    //            clickEvent.intoEnemyZone = true;
    //            clickEvent.destroyedObject = hitInfo.collider.gameObject;
    //        }
    //    }
    //}

    private void TracePath()
    {
        if (leftClicked == false) return;

        if ((mouseOnTileX.value == commonFeatures.invalidIndex) || (mouseOnTileZ.value == commonFeatures.invalidIndex)) return;

        clickEvent.pathFound = false;
        clickEvent.doorTileClicked = false;
        clickEvent.doorTile = null;

        if (mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value].Type == TileType.Door)
        {
            clickEvent.doorTileClicked = true;
            clickEvent.doorTile = mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value];
        }

        //clickEvent.pathFound = aStar.FindPath(mapData.TileData, mapData.TileData[currentTileX.value, currentTileZ.value], mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value], clickEvent.doorTileClicked);
        if (phaseManager.CurrentPhase == phaseManager.Phase_Explore) clickEvent.pathFound = aStar.FindPath(mapData.TileData, mapData.TileData[currentTileX.value, currentTileZ.value], mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value], clickEvent.doorTileClicked);
        else if (phaseManager.CurrentPhase == phaseManager.Phase_Battle)
        {
            //Character_InBattle currentTurnCharacter = battleManager.GetComponent<Manager_Battle>().CurrentTurnCharacter;
            Character_InBattle currentTurnCharacter = battleManager.GetComponent<Manager_Battle2>().turnController.CurrentTurnCharacter;
            clickEvent.pathFound = aStar.FindPath(mapData.TileData, mapData.TileData[currentTurnCharacter.StandingTileX, currentTurnCharacter.StandingTileZ], mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value]);
        }

        if (clickEvent.pathFound == false)
        {
            print("Failed to find path.");
            return;
        }

        //for (int i = 0; i < aStar.FinalTrack.Count - 1; i++)
        //{
        //    Node_AStar currentStart = aStar.FinalTrack[i];
        //    Node_AStar currentEnd = aStar.FinalTrack[i + 1];
        //    Vector3 start = new Vector3((float)mapData.TileData[currentStart.X, currentStart.Z].X, 1.0f, (float)mapData.TileData[currentStart.X, currentStart.Z].Z);
        //    Vector3 end = new Vector3((float)mapData.TileData[currentEnd.X, currentEnd.Z].X, 1.0f, (float)mapData.TileData[currentEnd.X, currentEnd.Z].Z);

        //    Debug.DrawLine(start, end, Color.blue);
        //}
    }

    private void SetClickedCursorMaterial()
    {
        if (leftClicked == false) return;

        if ((mouseOnTileX.value == commonFeatures.invalidIndex) || (mouseOnTileZ.value == commonFeatures.invalidIndex)) return;

        switch (mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value].Type)
        {
            case TileType.Floor:
                this.GetComponent<Renderer>().material = green;
                break;
            case TileType.Door:
                this.GetComponent<Renderer>().material = yellow;
                break;
        }
    }

    private void ResetDoorColors()
    {
        for (int i = 0; i < mapData.Doors.Count; i++)
        {
            if (mapData.Doors[i].Door.Highlighted == false) continue;

            mapData.Doors[i].Door.ResetDoorColor();
        }
    }

    private void HighlightDoor()
    {
        if ((mouseOnTileX.value == commonFeatures.invalidIndex) || (mouseOnTileZ.value == commonFeatures.invalidIndex)) return;

        if (mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value].Type != TileType.Door) return;

        mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value].Door.HighlightDoor();
    }
}
