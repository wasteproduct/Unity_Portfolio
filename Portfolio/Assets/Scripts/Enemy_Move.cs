using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using MapDataSet;

public class Enemy_Move : MonoBehaviour
{
    public Calculation_AStar aStar;

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
    }

    private IEnumerator Move()
    {
        int stop = 32;
        while (true)
        {
            if (stop <= 0) break;

            stop--;

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
