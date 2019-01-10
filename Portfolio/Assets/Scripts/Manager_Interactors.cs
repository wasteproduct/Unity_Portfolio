using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapDataSet;
using TileDataSet;

[CreateAssetMenu(fileName = "", menuName = "Manager/Interactors", order = 1)]
public class Manager_Interactors : ScriptableObject
{
    [SerializeField]
    private GameObject treasureBox;
    [SerializeField]
    private GameObject nPCAcquireChan;

    private List<GameObject> treasureBoxes;
    private List<GameObject> nPCs;

    public void Editor_ClearInteractors()
    {
        nPCs.Clear();
        treasureBoxes.Clear();
    }

    public void SetInteractors(Map_Data mapData, bool editor)
    {
        DestroyInteractors(editor);

        SetNPC(mapData);
        SetTreasureBoxes(mapData);
    }

    public void SetNPC(Map_Data mapData)
    {
        nPCs = new List<GameObject>();

        int nPCX = mapData.StartingTile.X + 3;
        int nPCZ = mapData.StartingTile.Z + 3;

        GameObject newNPC = Instantiate(nPCAcquireChan, new Vector3(nPCX, 0, nPCZ), Quaternion.Euler(0.0f, 180.0f, 0.0f));
        mapData.TileData[nPCX, nPCZ].Interactor = newNPC.GetComponent<Interactor_NPC>();
        mapData.TileData[nPCX, nPCZ].Type = TileType.Interactor;

        nPCs.Add(newNPC);
    }

    public void DestroyInteractors(bool editor)
    {
        DestroyNPCs(editor);
        DestroyTreasureBoxes(editor);
    }

    public void DestroyNPCs(bool editor)
    {
        for (int i = 0; i < nPCs.Count; i++)
        {
            if (editor == true) DestroyImmediate(nPCs[i].gameObject);
            else Destroy(nPCs[i].gameObject);
        }
        nPCs.Clear();
    }

    public void DestroyTreasureBoxes(bool editor)
    {
        for (int i = 0; i < treasureBoxes.Count; i++)
        {
            if (editor == true) DestroyImmediate(treasureBoxes[i].gameObject);
            else Destroy(treasureBoxes[i].gameObject);
        }
        treasureBoxes.Clear();
    }

    public void SetTreasureBoxes(Map_Data mapData)
    {
        treasureBoxes = new List<GameObject>();

        List<Room> rooms = mapData.Rooms;

        for (int i = 0; i < rooms.Count; i++)
        {
            Room currentRoom = rooms[i];
            int boxNumber = Random.Range(1, 3);

            for (int j = 0; j < boxNumber; j++)
            {
                int boxX = Random.Range(currentRoom.StartX + 2, currentRoom.EndX - 2);
                int boxZ = Random.Range(currentRoom.StartZ + 2, currentRoom.EndZ - 2);

                if (mapData.TileData[boxX, boxZ].Type != TileType.Floor) break;

                GameObject newBox = Instantiate(treasureBox, new Vector3(boxX, 0, boxZ), Quaternion.Euler(0.0f, 180.0f, 0.0f));
                mapData.TileData[boxX, boxZ].Interactor = newBox.GetComponent<Interactor_ObjectTreasureBox>();
                mapData.TileData[boxX, boxZ].Type = TileType.Interactor;

                treasureBoxes.Add(newBox);
            }
        }
    }

    private void OnDisable()
    {
        if (treasureBoxes != null) treasureBoxes.Clear();
        if (nPCs != null) nPCs.Clear();
    }
}
