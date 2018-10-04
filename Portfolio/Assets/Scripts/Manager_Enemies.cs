using UnityEngine;

public class Manager_Enemies : MonoBehaviour
{
    public EnemyZonesData zonesData;
    public GameObject enemyObject;
    public GameObject enemyZonePrefab;

    // Use this for initialization
    void Start()
    {
        CreateEnemyZones();

        PlaceEnemies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateEnemyZones()
    {
        for (int i = 0; i < zonesData.Zones.Count; i++)
        {
            GameObject newEnemyZone = Instantiate<GameObject>(enemyZonePrefab);
            newEnemyZone.GetComponent<Map_EnemyZone>().SetZone(zonesData.Zones[i]);
        }
    }

    private void PlaceEnemies()
    {
        for (int i = 0; i < zonesData.Zones.Count; i++)
        {
            int emptySpace = Random.Range(0, 4);

            PlaceEnemies(emptySpace, i);
        }
    }

    private void PlaceEnemies(int emptySpace, int zoneIndex)
    {
        const int left = 0;
        const int right = 1;
        const int upper = 2;
        const int lower = 3;

        Vector3 leftPosition = new Vector3((float)zonesData.Zones[zoneIndex].leftTile.X, 0.0f, (float)zonesData.Zones[zoneIndex].leftTile.Z);
        Vector3 rightPosition = new Vector3((float)zonesData.Zones[zoneIndex].rightTile.X, 0.0f, (float)zonesData.Zones[zoneIndex].rightTile.Z);
        Vector3 upperPosition = new Vector3((float)zonesData.Zones[zoneIndex].upperTile.X, 0.0f, (float)zonesData.Zones[zoneIndex].upperTile.Z);
        Vector3 lowerPosition = new Vector3((float)zonesData.Zones[zoneIndex].lowerTile.X, 0.0f, (float)zonesData.Zones[zoneIndex].lowerTile.Z);

        switch (emptySpace)
        {
            case left:
                Instantiate<GameObject>(enemyObject, rightPosition, Quaternion.identity);
                Instantiate<GameObject>(enemyObject, upperPosition, Quaternion.identity);
                Instantiate<GameObject>(enemyObject, lowerPosition, Quaternion.identity);
                break;
            case right:
                Instantiate<GameObject>(enemyObject, leftPosition, Quaternion.identity);
                Instantiate<GameObject>(enemyObject, upperPosition, Quaternion.identity);
                Instantiate<GameObject>(enemyObject, lowerPosition, Quaternion.identity);
                break;
            case upper:
                Instantiate<GameObject>(enemyObject, leftPosition, Quaternion.identity);
                Instantiate<GameObject>(enemyObject, rightPosition, Quaternion.identity);
                Instantiate<GameObject>(enemyObject, lowerPosition, Quaternion.identity);
                break;
            case lower:
                Instantiate<GameObject>(enemyObject, leftPosition, Quaternion.identity);
                Instantiate<GameObject>(enemyObject, rightPosition, Quaternion.identity);
                Instantiate<GameObject>(enemyObject, upperPosition, Quaternion.identity);
                break;
        }
    }
}
