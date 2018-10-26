using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;
using MapDataSet;
using Battle;

[CreateAssetMenu(fileName = "", menuName = "Calculation/Move", order = 1)]
public class Calculation_Move : ScriptableObject
{
    public bool moving = false;
    public Calculation_AStar aStar;
    public Battle_TurnController turnController;
    public Battle_MovableTilesManager movableTilesManager;
    public Calculation_Turn rotationCalculator;

    private readonly float elapsedTimeLimit = .2f;

    public float ElapsedTimeLimit { get { return elapsedTimeLimit; } }
    public Map_Data MapData { get; private set; }
    public List<Node_AStar> Track { get; private set; }

    public void SetTrack(Map_Data mapData)
    {
        MapData = mapData;

        int startX = turnController.CurrentTurnCharacter.StandingTileX;
        int startZ = turnController.CurrentTurnCharacter.StandingTileZ;

        bool pathFound = aStar.FindPath(MapData.TileData, MapData.TileData[startX, startZ], movableTilesManager.DestinationTile);

        if (pathFound == false)
        {
            Debug.Log("Failed to find path.");
            return;
        }

        Track = new List<Node_AStar>(aStar.FinalTrack);
    }

    public Quaternion LerpRotation(int nextTileIndex, float elapsedTime, Quaternion startingRotation)
    {
        Node_AStar startNode = Track[nextTileIndex - 1];
        Node_AStar targetNode = Track[nextTileIndex];

        int startX = startNode.X;
        int startZ = startNode.Z;

        int endX = targetNode.X;
        int endZ = targetNode.Z;

        float lerpTime = elapsedTime / elapsedTimeLimit;

        return rotationCalculator.LerpRotation(startX, startZ, endX, endZ, startingRotation, lerpTime);
    }

    public Vector3 LerpPosition(int nextTileIndex, float elapsedTime)
    {
        Node_AStar startNode = Track[nextTileIndex - 1];
        Node_AStar targetNode = Track[nextTileIndex];

        float startX = MapData.TileData[startNode.X, startNode.Z].X;
        float startZ = MapData.TileData[startNode.X, startNode.Z].Z;

        float targetX = MapData.TileData[targetNode.X, targetNode.Z].X;
        float targetZ = MapData.TileData[targetNode.X, targetNode.Z].Z;

        float lerpTime = elapsedTime / elapsedTimeLimit;

        float x = Mathf.Lerp(startX, targetX, lerpTime);
        float z = Mathf.Lerp(startZ, targetZ, lerpTime);

        return new Vector3(x, 0.0f, z);
    }
}
