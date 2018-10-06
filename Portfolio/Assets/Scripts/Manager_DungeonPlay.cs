using UnityEngine;
using AStar;
using Battle;

public class Manager_DungeonPlay : MonoBehaviour
{
    public GameObject tileMap;
    public GameObject battleManager;
    public Calculation_AStar aStar;
    public Manager_Layers layers;
    public Manager_CommonFeatures commonFeatures;
    public Manager_DungeonPhase phaseManager;

    public Variable_DungeonPhase CurrentPhase { get { return phaseManager.CurrentPhase; } }

    // Use this for initialization
    void Start()
    {
        aStar.Initialize(tileMap.GetComponent<Map_Main>().MapData);

        phaseManager.PhaseToExplore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBattle()
    {
        phaseManager.PhaseToBattle();

        battleManager.gameObject.SetActive(true);

        battleManager.GetComponent<Manager_Battle>().Initialize();
    }
}
