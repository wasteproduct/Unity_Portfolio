using System.Collections.Generic;
using UnityEngine;
using TileDataSet;

[CreateAssetMenu(fileName = "", menuName = "Enemy/ZonesData", order = 1)]
public class EnemyZonesData : ScriptableObject
{
    public struct EnemyZone
    {
        public Map_TileData centerTile;
        public Map_TileData leftTile;
        public Map_TileData rightTile;
        public Map_TileData upperTile;
        public Map_TileData lowerTile;
    }

    public const int zoneLength = 11;
    
    private List<EnemyZone> zones = new List<EnemyZone>();
    public List<EnemyZone> Zones { get { return zones; } }

    public void AddNewZone(Map_TileData center, Map_TileData left, Map_TileData right, Map_TileData upper, Map_TileData lower)
    {
        EnemyZone newZone = new EnemyZone();

        newZone.centerTile = center;
        newZone.leftTile = left;
        newZone.rightTile = right;
        newZone.upperTile = upper;
        newZone.lowerTile = lower;

        zones.Add(newZone);
    }

    private void OnDisable()
    {
        for (int i = zones.Count - 1; i >= 0; i--)
        {
            zones.RemoveAt(i);
        }

        zones.Clear();
    }
}
