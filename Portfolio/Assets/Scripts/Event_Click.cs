using UnityEngine;
using TileDataSet;

[CreateAssetMenu(fileName = "", menuName = "Event/Click", order = 1)]
public class Event_Click : CustomEvent
{
    //public bool doorTileClicked;
    public bool pathFound;
    public bool interactorClicked;
    //public Map_TileData doorTile;
    public Map_TileData destinationTile;
    public Map_TileData interactorTile;

    public void Initialize()
    {
        //doorTileClicked = false;
        pathFound = false;
        interactorClicked = false;
        //doorTile = null;
        destinationTile = null;
        interactorTile = null;
    }
}
