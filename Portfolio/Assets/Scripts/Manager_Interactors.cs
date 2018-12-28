using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapDataSet;

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
        treasureBoxes = null;
    }

    public void SetTreasureBoxes(Map_Data mapData)
    {
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

                treasureBoxes.Add(Instantiate(treasureBox, new Vector3(boxX, 0, boxZ), Quaternion.identity));

                previousX = boxX;
                previousZ = boxZ;
            }
        }
    }
}
