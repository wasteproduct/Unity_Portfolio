using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using MapDataSet;

public class Character_ExploreCaptain : Character_Explore
{
    public Calculation_AStar aStar;
    public Manager_Layers layers;
    public Calculation_Turn rotationCalculator;

    public Variable_Int currentTileX;
    public Variable_Int currentTileZ;

    public GameObject SteppedEnemyZone { get; private set; }
    public Map_Data MapData { get; private set; }
    public bool IntoEnemyZone { get; private set; }

    public override void SetTrack(List<Node_AStar> track) { }

    public void DestroySteppedEnemyZone()
    {
        Destroy(SteppedEnemyZone.gameObject);
        SteppedEnemyZone = null;
        IntoEnemyZone = false;
    }

    public override void Initialize(Map_Data mapData)
    {
        MapData = mapData;

        IntoEnemyZone = false;
        SteppedEnemyZone = null;

        StartingRotation = gameObject.transform.rotation;
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

        gameObject.transform.position = new Vector3(x, 0.0f, z);
        gameObject.transform.rotation = rotationCalculator.LerpRotation((int)startX, (int)startZ, (int)targetX, (int)targetZ, StartingRotation, lerpTime);
    }

    public override void UpdateStartingRotation()
    {
        StartingRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        currentTileX.value = (int)(gameObject.transform.position.x + .5f);
        currentTileZ.value = (int)(gameObject.transform.position.z + .5f);

        StandingTileX = (int)(gameObject.transform.position.x + .5f);
        StandingTileZ = (int)(gameObject.transform.position.z + .5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer == layers.EnemyZone)
        {
            IntoEnemyZone = true;
            SteppedEnemyZone = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (1 << other.gameObject.layer == layers.EnemyZone)
        {
            IntoEnemyZone = false;
            SteppedEnemyZone = null;
        }
    }
}
