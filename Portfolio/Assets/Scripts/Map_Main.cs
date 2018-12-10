using System.Collections.Generic;
using UnityEngine;
using MapDataSet;
using MapObject;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Map_Main : MonoBehaviour
{
    public Manager_CommonFeatures commonFeatures;

    public MapSize mapSize;
    public GameObject dungeonFloor;
    public GameObject dungeonWall;
    public GameObject dungeonDoor;
    public EnemyZonesData enemyZonesData;
    public GameObject fogOfWar;

    public Map_Data MapData { get; private set; }

    // Use this for initialization
    void Start()
    {
        GenerateMap();

        fogOfWar.GetComponent<FogOfWar_Manager>().Initialize(MapData.TilesRow, MapData.TilesColumn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateMap()
    {
        MapData = new Map_Data(mapSize, commonFeatures, enemyZonesData);

        //ClearAll();

        SetMapMeshes();

        CombineMapMeshes();

        SetObjects();
    }

    private void SetObjects()
    {
        SetDoors();
    }

    private void SetDoors()
    {
        for (int i = 0; i < MapData.Doors.Count; i++)
        {
            Quaternion rotation = Quaternion.identity;

            switch (MapData.Doors[i].Walls[0])
            {
                case TileDataSet.WallDirection.Left:
                    rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                    break;
                case TileDataSet.WallDirection.Right:
                    rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                    break;
                case TileDataSet.WallDirection.Far:
                    rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                    break;
            }

            GameObject newDoor = Instantiate(dungeonDoor, new Vector3(MapData.Doors[i].X, 0.0f, MapData.Doors[i].Z), rotation, transform);

            Object_Door newDoorHandler = newDoor.GetComponentInChildren<Object_Door>();
            newDoorHandler.SetIndex(MapData.Doors[i].X, MapData.Doors[i].Z);
            MapData.Doors[i].Door = newDoorHandler;
        }
    }

    private void CombineMapMeshes()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>(true);

        CombineInstance[] instances = new CombineInstance[meshFilters.Length];

        List<CombineInstance> floors = new List<CombineInstance>();
        List<CombineInstance> walls = new List<CombineInstance>();
        List<Material> materials = new List<Material>();

        Material floorMaterial = null;
        Material wallMaterial = null;

        for (int i = 0; i < meshFilters.Length; i++)
        {
            if (meshFilters[i].transform == transform) continue;

            instances[i] = new CombineInstance();

            instances[i].mesh = meshFilters[i].sharedMesh;
            instances[i].transform = meshFilters[i].transform.localToWorldMatrix;

            if (meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial.name == "floor_A")
            {
                floorMaterial = meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial;
                floors.Add(instances[i]);
            }
            else if (meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial.name == "wall_A")
            {
                wallMaterial = meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial;
                walls.Add(instances[i]);
            }
        }

        materials.Add(floorMaterial);
        materials.Add(wallMaterial);

        Mesh combinedFloor = new Mesh();
        combinedFloor.CombineMeshes(floors.ToArray());

        GetComponent<MeshCollider>().sharedMesh = combinedFloor;

        Mesh combinedWall = new Mesh();
        combinedWall.CombineMeshes(walls.ToArray());

        CombineInstance[] combinedInstances = new CombineInstance[2];
        combinedInstances[0].mesh = combinedFloor;
        combinedInstances[0].transform = transform.localToWorldMatrix;
        combinedInstances[1].mesh = combinedWall;
        combinedInstances[1].transform = transform.localToWorldMatrix;

        GetComponent<MeshCollider>().sharedMesh = combinedFloor;

        Mesh ultimateMesh = new Mesh();
        ultimateMesh.CombineMeshes(combinedInstances, false);

        GetComponent<MeshRenderer>().sharedMaterials = new Material[2];

        for (int i = 0; i < 2; i++)
        {
            GetComponent<MeshRenderer>().sharedMaterials = materials.ToArray();
        }

        GetComponent<MeshFilter>().mesh = ultimateMesh;

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void SetMapMeshes()
    {
        for (int z = 0; z < MapData.TilesColumn; z++)
        {
            for (int x = 0; x < MapData.TilesRow; x++)
            {
                switch (MapData.TileData[x, z].Type)
                {
                    case TileDataSet.TileType.None:
                        break;
                    case TileDataSet.TileType.Wall:
                        BuildWall(x, z);
                        break;
                    default:
                        Instantiate(dungeonFloor, new Vector3(x, 0.0f, z), Quaternion.identity, transform);
                        break;
                }
            }
        }
    }

    private void BuildWall(int x, int z)
    {
        for (int i = 0; i < MapData.TileData[x, z].Walls.Count; i++)
        {
            Quaternion rotation = Quaternion.identity;

            switch (MapData.TileData[x, z].Walls[i])
            {
                case TileDataSet.WallDirection.Left:
                    rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                    break;
                case TileDataSet.WallDirection.Right:
                    rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                    break;
                case TileDataSet.WallDirection.Far:
                    rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                    break;
            }

            Instantiate(dungeonWall, new Vector3(x, 0.0f, z), rotation, transform);
        }
    }
}
