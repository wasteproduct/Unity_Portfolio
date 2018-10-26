using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character_Explore : MonoBehaviour
{
    public int StandingTileX { get; protected set; }
    public int StandingTileZ { get; protected set; }
    public Quaternion StartingRotation { get; protected set; }

    public abstract void Initialize(MapDataSet.Map_Data mapData);
    public abstract void Move(int targetIndex, float lerpTime);
    public abstract void SetTrack(List<AStar.Node_AStar> track);
    public abstract void UpdateStartingRotation();
}
