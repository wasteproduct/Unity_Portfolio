using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using MapDataSet;

public class Character_ExploreFellow : Character_Explore
{
    private Map_Data mapData;
    private List<Node_AStar> privateTrack;

    public override void Initialize(Map_Data MapData)
    {
        mapData = MapData;
    }

    // Update is called once per frame
    void Update()
    {
        this.StandingTileX = (int)(this.gameObject.transform.position.x + .5f);
        this.StandingTileZ = (int)(this.gameObject.transform.position.z + .5f);
    }

    public override void SetTrack(List<Node_AStar> track)
    {
        privateTrack = new List<Node_AStar>(track);
    }

    public override void Move(int targetIndex, float lerpTime)
    {
        Node_AStar startNode = privateTrack[targetIndex - 1];
        Node_AStar targetNode = privateTrack[targetIndex];

        float startX = mapData.TileData[startNode.X, startNode.Z].X;
        float startZ = mapData.TileData[startNode.X, startNode.Z].Z;

        float targetX = mapData.TileData[targetNode.X, targetNode.Z].X;
        float targetZ = mapData.TileData[targetNode.X, targetNode.Z].Z;

        float x = Mathf.Lerp(startX, targetX, lerpTime);
        float z = Mathf.Lerp(startZ, targetZ, lerpTime);

        this.gameObject.transform.position = new Vector3(x, 0.0f, z);
    }
}
