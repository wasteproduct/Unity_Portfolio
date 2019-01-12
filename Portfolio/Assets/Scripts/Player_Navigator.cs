using System.Collections.Generic;
using UnityEngine;
using MapDataSet;

namespace Player
{
    public class Player_Navigator : MonoBehaviour
    {
        [SerializeField]
        private Variable_Int currentTileX;
        [SerializeField]
        private Variable_Int currentTileZ;
        [SerializeField]
        private UI_MinimapIcon minimapIcon;

        public List<Room> Rooms { get; private set; }

        public void UpdateMinimap()
        {
            Room currentRoom = null;

            for (int i = 0; i < Rooms.Count; i++)
            {
                if (InRangeX(currentTileX.value, Rooms[i].StartX, Rooms[i].EndX) == false) continue;

                if (InRangeZ(currentTileZ.value, Rooms[i].StartZ, Rooms[i].EndZ) == false) continue;

                currentRoom = Rooms[i];

                break;
            }

            if (currentRoom == null)
            {
                print("Failed to find room.");
                return;
            }

            minimapIcon.FixPosition(new Vector3(currentRoom.LocatedArea.CenterX, 0, currentRoom.LocatedArea.CenterZ));
        }

        public void Initialize(List<Room> rooms)
        {
            Rooms = rooms;

            UpdateMinimap();
        }

        private bool InRangeX(int x, int minimumX, int maximumX) { return (x >= minimumX) && (x <= maximumX); }

        private bool InRangeZ(int z, int minimumZ, int maximumZ) { return (z >= minimumZ) && (z <= maximumZ); }
    }
}
