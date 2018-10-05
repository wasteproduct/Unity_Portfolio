using UnityEngine;
using MapDataSet;
using TileDataSet;
using AStar;

public class Cursor : MonoBehaviour
{
    public GameObject dungeonPlay;

    public Material defaultColor;
    public Material green;
    public Material red;
    public Material yellow;

    public Event_Click clickEvent;

    public Variable_Int mouseOnTileX;
    public Variable_Int mouseOnTileZ;
    public Calculation_AStar aStar;
    public Variable_Bool playerMoving;
    public Variable_Int currentTileX;
    public Variable_Int currentTileZ;

    private Map_Data mapData;
    private Manager_Layers layers;
    private Manager_CommonFeatures commonFeatures;
    private bool leftClicked;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Renderer>().material = defaultColor;
        
        mapData = dungeonPlay.GetComponent<Manager_DungeonPlay>().tileMap.GetComponent<Map_Main>().MapData;
        layers = dungeonPlay.GetComponent<Manager_DungeonPlay>().layers;
        commonFeatures = dungeonPlay.GetComponent<Manager_DungeonPlay>().commonFeatures;
        leftClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        ResetDoorColors();

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
        if (playerMoving.flag == true) return;

        if (Input.GetMouseButtonDown(0))
        {
            if ((mouseOnTileX.value == commonFeatures.invalidIndex) || (mouseOnTileZ.value == commonFeatures.invalidIndex)) return;

            leftClicked = true;
        }

        TracePath();

        if (Input.GetMouseButtonUp(0))
        {
            if (leftClicked == false) return;

            this.GetComponent<Renderer>().material = defaultColor;
            leftClicked = false;

            clickEvent.Run();
        }
    }

    private void TracePath()
    {
        if (leftClicked == false) return;

        if ((mouseOnTileX.value == commonFeatures.invalidIndex) || (mouseOnTileZ.value == commonFeatures.invalidIndex)) return;

        clickEvent.pathFound = false;
        clickEvent.doorTile = false;
        if (mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value].Type == TileType.Door) clickEvent.doorTile = true;

        clickEvent.pathFound = aStar.FindPath(mapData.TileData, mapData.TileData[currentTileX.value, currentTileZ.value], mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value], clickEvent.doorTile);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100.0f) == true)
        {
            if (1 << hitInfo.collider.gameObject.layer == (int)layers.EnemyZone) clickEvent.intoEnemyZone = true;
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
