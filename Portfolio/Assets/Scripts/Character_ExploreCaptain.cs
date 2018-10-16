using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using MapDataSet;

public class Character_ExploreCaptain : Character_Explore
{
    public Calculation_AStar aStar;
    public Manager_Layers layers;

    public Variable_Int currentTileX;
    public Variable_Int currentTileZ;

    private GameObject steppedEnemyZone;

    public Map_Data MapData { get; private set; }
    public bool IntoEnemyZone { get; private set; }

    public override void SetTrack(List<Node_AStar> track) { }

    public void DestroySteppedEnemyZone()
    {
        Destroy(steppedEnemyZone.gameObject);
        steppedEnemyZone = null;
        IntoEnemyZone = false;
    }

    public override void Initialize(Map_Data mapData)
    {
        MapData = mapData;

        IntoEnemyZone = false;
        steppedEnemyZone = null;
    }

    public override void Move(int targetIndex, float lerpTime)
    {
        Node_AStar startNode = aStar.FinalTrack[targetIndex - 1];
        Node_AStar targetNode = aStar.FinalTrack[targetIndex];

        float startX = MapData.TileData[startNode.X, startNode.Z].X;
        float startZ = MapData.TileData[startNode.X, startNode.Z].Z;

        float targetX = MapData.TileData[targetNode.X, targetNode.Z].X;
        float targetZ = MapData.TileData[targetNode.X, targetNode.Z].Z;

        float x = Mathf.Lerp(startX, targetX, lerpTime);
        float z = Mathf.Lerp(startZ, targetZ, lerpTime);

        this.gameObject.transform.position = new Vector3(x, 0.0f, z);
    }

    // Update is called once per frame
    void Update()
    {
        currentTileX.value = (int)(this.gameObject.transform.position.x + .5f);
        currentTileZ.value = (int)(this.gameObject.transform.position.z + .5f);

        this.StandingTileX = (int)(this.gameObject.transform.position.x + .5f);
        this.StandingTileZ = (int)(this.gameObject.transform.position.z + .5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer == (int)layers.EnemyZone)
        {
            IntoEnemyZone = true;
            steppedEnemyZone = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (1 << other.gameObject.layer == (int)layers.EnemyZone)
        {
            IntoEnemyZone = false;
            steppedEnemyZone = null;
        }
    }
}
