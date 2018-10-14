using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using AStar;
//using TileDataSet;
//using MapDataSet;

[CreateAssetMenu(fileName = "", menuName = "Calculation/Move", order = 1)]
public class Calculation_Move : ScriptableObject
{
    public bool moving = false;

    private readonly float elapsedTimeLimit = .2f;
    //private Map_Data mapData;

    public float ElapsedTimeLimit { get { return elapsedTimeLimit; } }

    //public void Initialize(Map_Data MapData)
    //{
    //    mapData = MapData;
    //}

    //public Vector3 LerpPosition(Node_AStar startNode, Node_AStar targetNode, float elapsedTime)
    //{
    //    Vector3 startPosition = new Vector3(mapData.TileData[startNode.X, startNode.Z].X, 0.0f, mapData.TileData[startNode.X, startNode.Z].Z);
    //    Vector3 targetPosition = new Vector3(mapData.TileData[targetNode.X, targetNode.Z].X, 0.0f, mapData.TileData[targetNode.X, targetNode.Z].Z);

    //    return Vector3.Lerp(startPosition, targetPosition, elapsedTime / elapsedTimeLimit);
    //}
}
