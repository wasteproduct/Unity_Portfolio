using UnityEngine;

public class Manager_Enemies : MonoBehaviour
{
    public EnemyZonesData zonesData;
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
        int zonesNumber = zonesData.Zones.Count;

        for (int i = 0; i < zonesNumber - 1; i++)
        {
            GameObject newEnemyZone = Instantiate(enemyZonePrefab);
            newEnemyZone.GetComponent<Map_EnemyZone>().SetZone(zonesData.Zones[i], false);
        }

        GameObject bossZone = Instantiate(enemyZonePrefab);
        bossZone.GetComponent<Map_EnemyZone>().SetZone(zonesData.Zones[zonesNumber - 1], true);

        //Test_BossOnly();
    }

    private void Test_BossOnly()
    {
        GameObject bossZone = Instantiate(enemyZonePrefab);
        bossZone.GetComponent<Map_EnemyZone>().SetZone(zonesData.Zones[0], true);
    }
}
