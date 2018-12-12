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
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateEnemyZones()
    {
        for (int i = 0; i < zonesData.Zones.Count; i++)
        {
            GameObject newEnemyZone = Instantiate(enemyZonePrefab);
            newEnemyZone.GetComponent<Map_EnemyZone>().SetZone(zonesData.Zones[i]);
        }
    }
}
