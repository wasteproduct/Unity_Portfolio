using UnityEngine;
using AStar;

public class Manager_DungeonPlay : MonoBehaviour
{
    public GameObject tileMap;
    public Calculation_AStar aStar;
    public Manager_Layers layers;
    public Manager_CommonFeatures commonFeatures;

    // Use this for initialization
    void Start()
    {
        aStar.Initialize(tileMap.GetComponent<Map_Main>().MapData);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
