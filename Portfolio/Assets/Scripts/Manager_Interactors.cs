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

    private List<GameObject> treasureBoxes;

    public void DestroyTreasureBoxes(bool editor)
    {
        for (int i = 0; i < treasureBoxes.Count; i++)
        {
            if (editor == true) DestroyImmediate(treasureBoxes[i].gameObject);
            else Destroy(treasureBoxes[i].gameObject);
        }
        treasureBoxes.Clear();
    }

    public void SetTreasureBoxes(Map_Data mapData, bool editor)
    {
        DestroyTreasureBoxes(editor);

        treasureBoxes = new List<GameObject>();

        List<Room> rooms = mapData.Rooms;

        for (int i = 0; i < rooms.Count; i++)
        {
            Room currentRoom = rooms[i];
            int boxNumber = Random.Range(1, 3);

            int previousX = -1;
            int previousZ = -1;
            for (int j = 0; j < boxNumber; j++)
            {
                int boxX = Random.Range(currentRoom.StartX + 2, currentRoom.EndX - 2);
                int boxZ = Random.Range(currentRoom.StartZ + 2, currentRoom.EndZ - 2);

                if ((boxX == previousX) && (boxZ == previousZ)) break;

                GameObject newBox = Instantiate(treasureBox, new Vector3(boxX, 0, boxZ), Quaternion.Euler(0.0f, 180.0f, 0.0f));
                mapData.TileData[boxX, boxZ].Interactor = newBox.GetComponent<Object_TreasureBox>();
                mapData.TileData[boxX, boxZ].Type = TileType.Interactor;

                treasureBoxes.Add(newBox);

                previousX = boxX;
                previousZ = boxZ;
            }
        }
    }

    private void OnDisable()
    {
        treasureBoxes.Clear();
    }
}
