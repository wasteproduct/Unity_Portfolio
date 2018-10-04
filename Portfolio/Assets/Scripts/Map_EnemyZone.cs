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

    private int zoneLeft = -1;
    private int zoneRight = -1;
    private int zoneBottom = -1;
    private int zoneTop = -1;

    public void SetZone(EnemyZonesData.EnemyZone zoneData)
    {
        zoneLeft = zoneData.centerTile.X - EnemyZonesData.zoneLength / 2;
        zoneRight = zoneLeft + EnemyZonesData.zoneLength;
        zoneBottom = zoneData.centerTile.Z - EnemyZonesData.zoneLength / 2;
        zoneTop = zoneBottom + EnemyZonesData.zoneLength;

        CreateZone();
    }

    private void CreateZone()
    {
        List<GameObject> tiles = new List<GameObject>();

        for (int z = zoneBottom; z < zoneTop; z++)
        {
            for (int x = zoneLeft; x < zoneRight; x++)
            {
                GameObject newTile = Instantiate<GameObject>(zoneTilePrefab, new Vector3((float)x, 0.0f, (float)z), Quaternion.identity);

                tiles.Add(newTile);
            }
        }

        CombineInstance[] combineInstances = new CombineInstance[tiles.Count];

        for(int i=0;i<tiles.Count;i++)
        {
            combineInstances[i] = new CombineInstance();

            combineInstances[i].mesh = tiles[i].GetComponent<MeshFilter>().sharedMesh;
            combineInstances[i].transform = tiles[i].GetComponent<MeshFilter>().transform.localToWorldMatrix;
        }

        Mesh combinedZone = new Mesh();
        combinedZone.CombineMeshes(combineInstances);

        this.GetComponent<MeshCollider>().sharedMesh = combinedZone;
        this.GetComponent<MeshRenderer>().sharedMaterial = zoneTileMaterial;
        this.GetComponent<MeshFilter>().mesh = combinedZone;

        for (int i = tiles.Count - 1; i >= 0; i--)
        {
            Destroy(tiles[i].gameObject);
        }

        tiles.Clear();
    }
}
