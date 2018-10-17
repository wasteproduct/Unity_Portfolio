using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using MapDataSet;

public class Character_InBattle : MonoBehaviour
{
    public Calculation_AStar aStar;

    // temporary
    public int AttackRange { get; private set; }
    public MeshRenderer meshRenderer;

    public Map_Data MapData { get; private set; }
    public bool Dead { get; private set; }
    public bool TurnFinished { get; private set; }
    public int StandingTileX { get; private set; }
    public int StandingTileZ { get; private set; }
    public bool ActionFinished()
    {
        TurnFinished = true;
        return true;
    }

    public void SetTurnFinished(bool flag) { TurnFinished = flag; }

    // temporary
    public void HighlightAsTarget(bool flag)
    {
        meshRenderer.material.color = (flag == true) ? Color.red : Color.white;
    }

    public void Initialize(Map_Data mapData, bool enemyCharacter)
    {
        MapData = mapData;

        Dead = false;
        TurnFinished = false;

        this.StandingTileX = (int)(this.gameObject.transform.position.x + .5f);
        this.StandingTileZ = (int)(this.gameObject.transform.position.z + .5f);

        if (enemyCharacter == true) this.gameObject.layer = LayerMask.NameToLayer("Enemy");

        // temporary
        AttackRange = 3;
    }

    public void Move(int targetIndex, float lerpTime)
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
        this.StandingTileX = (int)(this.gameObject.transform.position.x + .5f);
        this.StandingTileZ = (int)(this.gameObject.transform.position.z + .5f);
    }
}
