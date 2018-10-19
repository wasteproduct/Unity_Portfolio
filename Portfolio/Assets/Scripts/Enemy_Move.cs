using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using MapDataSet;
using TileDataSet;

public class Enemy_Move : MonoBehaviour
{
    public delegate void Delegate_Action();

    public Calculation_AStar aStar;
    public Calculation_Move moveController;

    private Character_InBattle inBattleScript;
    private Delegate_Action StartAction;

    public Map_Data MapData { get; private set; }

    public void Initialize(Map_Data mapData, Delegate_Action startAction)
    {
        MapData = mapData;

        inBattleScript = this.gameObject.GetComponent<Character_InBattle>();

        StartAction = startAction;
    }

    public void StartMoving(List<GameObject> movableTiles, GameObject target)
    {
        int closestDistance = 99999999;
        GameObject destinationTile = null;
        Character_InBattle targetScript = target.GetComponent<Character_InBattle>();

        for (int i = 0; i < movableTiles.Count; i++)
        {
            Map_TileData tileData = movableTiles[i].GetComponent<Tile_MovableInBattle>().TileData;
            int distance = Mathf.Abs(targetScript.StandingTileX - tileData.X) + Mathf.Abs(targetScript.StandingTileZ - tileData.Z);

            if (distance < closestDistance)
            {
                destinationTile = movableTiles[i];
                closestDistance = distance;
            }
        }

        StartCoroutine(Move(destinationTile.GetComponent<Tile_MovableInBattle>().TileData));
    }

    private IEnumerator Move(Map_TileData destinationTileData)
    {
        float elapsedTime = 0.0f;
        float lerpTime = 0.0f;
        float startX = MapData.TileData[inBattleScript.StandingTileX, inBattleScript.StandingTileZ].X;
        float startZ = MapData.TileData[inBattleScript.StandingTileX, inBattleScript.StandingTileZ].Z;
        float targetX = MapData.TileData[destinationTileData.X, destinationTileData.Z].X;
        float targetZ = MapData.TileData[destinationTileData.X, destinationTileData.Z].Z;

        while (true)
        {
            if (elapsedTime >= moveController.ElapsedTimeLimit)
            {
                StartAction();
                break;
            }

            elapsedTime += Time.deltaTime;
            lerpTime = elapsedTime / moveController.ElapsedTimeLimit;

            float x = Mathf.Lerp(startX, targetX, lerpTime);
            float z = Mathf.Lerp(startZ, targetZ, lerpTime);

            this.gameObject.transform.position = new Vector3(x, 0.0f, z);

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
