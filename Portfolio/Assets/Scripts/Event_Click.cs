using UnityEngine;
using TileDataSet;

[CreateAssetMenu]
public class Event_Click : CustomEvent
{
    public bool doorTile = false;
    public bool pathFound = false;
    public bool intoEnemyZone = false;
    public GameObject destroyedObject = null;
    public Map_TileData destinationTile = null;
}
