using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using MapDataSet;

public class Enemy_Move : MonoBehaviour
{
    public Calculation_AStar aStar;
    public Calculation_Move moveController;

    private Character_InBattle inBattleScript;

    public Map_Data MapData { get; private set; }

    public void Initialize(Map_Data mapData)
    {
        MapData = mapData;

        inBattleScript = this.gameObject.GetComponent<Character_InBattle>();
    }

    public void StartMoving(Character_InBattle target)
    {
        bool pathFound = aStar.FindPath(MapData.TileData, MapData.TileData[inBattleScript.StandingTileX, inBattleScript.StandingTileZ], MapData.TileData[target.StandingTileX, target.StandingTileZ]);

        if (pathFound == false)
        {
            print("Failed to find path.");
            return;
        }

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        float elapsedTime = 0.0f;
        float lerpTime = 0.0f;

        while (true)
        {
            if (elapsedTime >= moveController.ElapsedTimeLimit)
            {
                // 액션 시작해야 한다
                break;
            }

            elapsedTime += Time.deltaTime;
            lerpTime = elapsedTime / moveController.ElapsedTimeLimit;

            Node_AStar startNode = aStar.FinalTrack[0];
            Node_AStar targetNode = aStar.FinalTrack[1];

            float startX = MapData.TileData[startNode.X, startNode.Z].X;
            float startZ = MapData.TileData[startNode.X, startNode.Z].Z;

            float targetX = MapData.TileData[targetNode.X, targetNode.Z].X;
            float targetZ = MapData.TileData[targetNode.X, targetNode.Z].Z;

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
