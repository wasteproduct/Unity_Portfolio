using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Map_EnemyZone : MonoBehaviour
{
    [SerializeField]
    private GameObject zoneTilePrefab;
    [SerializeField]
    private Material zoneTileMaterial;
    [SerializeField]
    private GameObject slimeGirl;
    [SerializeField]
    private GameObject bigBully;
    [SerializeField]
    private UI_MinimapIcon minimapIcon;

    public EnemyZonesData.EnemyZone ZoneData { get; private set; }
    public List<GameObject> StayingEnemies { get; private set; }

    public void SetZone(EnemyZonesData.EnemyZone zoneData, bool bossArea)
    {
        ZoneData = zoneData;

        CreateZone();

        SetEnemies(bossArea);

        minimapIcon.SetIcon(new Vector3(ZoneData.centerTile.X, 0, ZoneData.centerTile.Z), bossArea);
    }

    private void SetEnemies(bool bossArea)
    {
        StayingEnemies = new List<GameObject>();

        if (bossArea == true)
        {
            Vector3 bossPosition = new Vector3(ZoneData.centerTile.X, 0, ZoneData.centerTile.Z);

            StayingEnemies.Add(Instantiate(bigBully, bossPosition, Quaternion.identity));
        }
        else
        {
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
                    StayingEnemies.Add(Instantiate(slimeGirl, rightPosition, Quaternion.identity));
                    StayingEnemies.Add(Instantiate(slimeGirl, upperPosition, Quaternion.identity));
                    StayingEnemies.Add(Instantiate(slimeGirl, lowerPosition, Quaternion.identity));
                    break;
                case right:
                    StayingEnemies.Add(Instantiate(slimeGirl, leftPosition, Quaternion.identity));
                    StayingEnemies.Add(Instantiate(slimeGirl, upperPosition, Quaternion.identity));
                    StayingEnemies.Add(Instantiate(slimeGirl, lowerPosition, Quaternion.identity));
                    break;
                case upper:
                    StayingEnemies.Add(Instantiate(slimeGirl, leftPosition, Quaternion.identity));
                    StayingEnemies.Add(Instantiate(slimeGirl, rightPosition, Quaternion.identity));
                    StayingEnemies.Add(Instantiate(slimeGirl, lowerPosition, Quaternion.identity));
                    break;
                case lower:
                    StayingEnemies.Add(Instantiate(slimeGirl, leftPosition, Quaternion.identity));
                    StayingEnemies.Add(Instantiate(slimeGirl, rightPosition, Quaternion.identity));
                    StayingEnemies.Add(Instantiate(slimeGirl, upperPosition, Quaternion.identity));
                    break;
            }
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
