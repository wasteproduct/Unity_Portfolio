using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapDataSet;

public class Character_InBattle : MonoBehaviour
{
    public Calculation_Move moveController;

    private float elapsedTime;
    private int nextTileIndex;

    // temporary
    public int AttackRange { get; private set; }
    public MeshRenderer meshRenderer;
    public int MovableDistance { get; private set; }

    public Map_Data MapData { get; private set; }
    public bool Dead { get; private set; }
    public bool TurnFinished { get; private set; }
    public int StandingTileX { get; private set; }
    public int StandingTileZ { get; private set; }
    public bool Arrived { get; private set; }
    public bool ActionFinished()
    {
        TurnFinished = true;
        return true;
    }

    public void SetTurnFinished(bool flag) { TurnFinished = flag; }

    public void SetTrack()
    {
        elapsedTime = 0.0f;
        nextTileIndex = 1;
        Arrived = false;

        moveController.SetTrack(MapData);
    }

    public void Move()
    {
        if (Arrived == true) return;

        elapsedTime += Time.deltaTime;

        this.gameObject.transform.position = moveController.LerpPosition(nextTileIndex, elapsedTime);

        if (elapsedTime >= moveController.ElapsedTimeLimit)
        {
            elapsedTime = 0.0f;
            nextTileIndex++;

            if (nextTileIndex >= moveController.Track.Count) Arrived = true;
        }
    }

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
        MovableDistance = 3;
        if (enemyCharacter == true)
        {
            AttackRange = 1;
            MovableDistance = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.StandingTileX = (int)(this.gameObject.transform.position.x + .5f);
        this.StandingTileZ = (int)(this.gameObject.transform.position.z + .5f);
    }
}
