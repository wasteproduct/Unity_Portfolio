using UnityEngine;
using TileDataSet;

[CreateAssetMenu(fileName = "", menuName = "Event/Click", order = 1)]
public class Event_Click : CustomEvent
{
    public bool doorTileClicked = false;
    public bool pathFound = false;
    public Map_TileData doorTile = null;
    public Map_TileData destinationTile = null;
}
