using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Map_EnemyZone : MonoBehaviour
{
    public GameObject zoneTilePrefab;
    public Material zoneTileMaterial;
    public GameObject enemyPrefab;

    public EnemyZonesData.EnemyZone ZoneData { get; private set; }
    public List<GameObject> StayingEnemies { get; private set; }

    public void SetZone(EnemyZonesData.EnemyZone zoneData)
    {
        ZoneData = zoneData;

        CreateZone();

        SetEnemies();
    }

    private void SetEnemies()
    {
        StayingEnemies = new List<GameObject>();

        const int left = 0;
        const int right = 1;
        const int upper = 2;
        const int lower = 3;

        int emptySpace = Random.Range(left, 4);

        Vector3 leftPosition = new Vector3(ZoneData.leftTile.X, 0.0f, ZoneData.leftTile.Z);
        Vector3 rightPosition = new Vector3(ZoneData.rightTile.X, 0.0f, ZoneData.rightTile.Z);
        Vector3 upperPosition = new Vector3(ZoneData.upperTile.X, 0.0f, ZoneData.upperTile.Z);
        Vector3 lowerPosition = new Vector3(ZoneData.lowerTile.X, 0.0f, ZoneData.lowerTile.Z);

        switch (emptySpace)
        {
            case left:
                StayingEnemies.Add(Instantiate(enemyPrefab, rightPosition, Quaternion.identity));
                StayingEnemies.Add(Instantiate(enemyPrefab, upperPosition, Quaternion.identity));
                StayingEnemies.Add(Instantiate(enemyPrefab, lowerPosition, Quaternion.identity));
                break;
            case right:
                StayingEnemies.Add(Instantiate(enemyPrefab, leftPosition, Quaternion.identity));
                StayingEnemies.Add(Instantiate(enemyPrefab, upperPosition, Quaternion.identity));
                StayingEnemies.Add(Instantiate(enemyPrefab, lowerPosition, Quaternion.identity));
                break;
            case upper:
                StayingEnemies.Add(Instantiate(enemyPrefab, leftPosition, Quaternion.identity));
                StayingEnemies.Add(Instantiate(enemyPrefab, rightPosition, Quaternion.identity));
                StayingEnemies.Add(Instantiate(enemyPrefab, lowerPosition, Quaternion.identity));
                break;
            case lower:
                StayingEnemies.Add(Instantiate(enemyPrefab, leftPosition, Quaternion.identity));
                StayingEnemies.Add(Instantiate(enemyPrefab, rightPosition, Quaternion.identity));
                StayingEnemies.Add(Instantiate(enemyPrefab, upperPosition, Quaternion.identity));
                break;
        }
    }

    private void CreateZone()
    {
        int zoneLeft = ZoneData.left;
        int zoneRight = ZoneData.right;
        int zoneBottom = ZoneData.bottom;
        int zoneTop = ZoneData.top;

        List<GameObject> tiles = new List<GameObject>();

        for (int z = zoneBottom; z < zoneTop; z++)
        {
            for (int x = zoneLeft; x < zoneRight; x++)
            {
                GameObject newTile = Instantiate(zoneTilePrefab, new Vector3(x, 0.0f, z), Quaternion.identity);

                tiles.Add(newTile);
            }
        }

        CombineInstance[] combineInstances = new CombineInstance[tiles.Count];

        for (int i = 0; i < tiles.Count; i++)
        {
            combineInstances[i] = new CombineInstance();

            combineInstances[i].mesh = tiles[i].GetComponent<MeshFilter>().sharedMesh;
            combineInstances[i].transform = tiles[i].GetComponent<MeshFilter>().transform.localToWorldMatrix;
        }

        Mesh combinedZone = new Mesh();
        combinedZone.CombineMeshes(combineInstances);

        GetComponent<MeshCollider>().sharedMesh = combinedZone;
        GetComponent<MeshRenderer>().sharedMaterial = zoneTileMaterial;
        GetComponent<MeshFilter>().mesh = combinedZone;

        for (int i = tiles.Count - 1; i >= 0; i--)
        {
            Destroy(tiles[i].gameObject);
        }

        tiles.Clear();
    }
}
