using UnityEngine;
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
        GetComponent<Renderer>().material = defaultColor;

        mapData = tileMap.GetComponent<Map_Main>().MapData;

        leftClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (choosingTarget.flag == true)
        {
            transform.position = Vector3.zero;
            return;
        }

        LeftClick();

        transform.position = new Vector3(mouseOnTileX.value, 0.0f, mouseOnTileZ.value);

        Ray ray = PassedRay();
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100.0f) == true)
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.blue);

            SetMouseOnTile(hitInfo);

            HighlightDoor();

            return;
        }

        mouseOnTileX.value = commonFeatures.invalidIndex;
        mouseOnTileZ.value = commonFeatures.invalidIndex;
    }

    private Ray PassedRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        Ray result = new Ray();

        if (Physics.Raycast(ray, out hitInfo, 100.0f) == true)
        {
            if (1 << hitInfo.collider.gameObject.layer == layers.FogOfWar)
            {
                result.origin = hitInfo.point + ray.direction * .2f;
                result.direction = ray.direction;
            }
        }

        Debug.DrawLine(ray.origin, result.origin, Color.red);

        return result;
    }

    private void SetMouseOnTile(RaycastHit hitInfo)
    {
        if ((1 << hitInfo.collider.gameObject.layer == layers.TileMap) || (1 << hitInfo.collider.gameObject.layer == layers.EnemyZone))
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

            GetComponent<Renderer>().material = defaultColor;
            leftClicked = false;

            clickEvent.Run();
        }
    }

    private void TracePath()
    {
        if (leftClicked == false) return;

        if ((mouseOnTileX.value == commonFeatures.invalidIndex) || (mouseOnTileZ.value == commonFeatures.invalidIndex)) return;

        clickEvent.pathFound = false;
        //clickEvent.doorTileClicked = false;
        //clickEvent.doorTile = null;
        clickEvent.interactorClicked = false;
        clickEvent.interactorTile = null;

        //if (mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value].Type == TileType.Door)
        //{
        //    clickEvent.doorTileClicked = true;
        //    clickEvent.doorTile = mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value];
        //}

        if (mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value].Type == TileType.Interactor)
        {
            clickEvent.interactorClicked = true;
            clickEvent.interactorTile = mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value];
        }

        if (phaseManager.CurrentPhase == phaseManager.Phase_Explore) clickEvent.pathFound = aStar.FindPath(mapData.TileData, mapData.TileData[currentTileX.value, currentTileZ.value], mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value], clickEvent.interactorClicked);
        else if (phaseManager.CurrentPhase == phaseManager.Phase_Battle)
        {
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
                GetComponent<Renderer>().material = green;
                break;
            case TileType.Door:
                GetComponent<Renderer>().material = yellow;
                break;
        }
    }

    private void HighlightDoor()
    {
        if ((mouseOnTileX.value == commonFeatures.invalidIndex) || (mouseOnTileZ.value == commonFeatures.invalidIndex)) return;

        if (mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value].Type != TileType.Door) return;

        mapData.TileData[mouseOnTileX.value, mouseOnTileZ.value].Door.HighlightDoor();
    }
}
