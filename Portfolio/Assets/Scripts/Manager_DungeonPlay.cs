using UnityEngine;
using AStar;
using Battle;
using System.Collections.Generic;

public class Manager_DungeonPlay : MonoBehaviour
{
    public GameObject tileMap;
    public GameObject battleManager;
    public Calculation_AStar aStar;
    public Manager_Layers layers;
    public Manager_CommonFeatures commonFeatures;
    public Manager_DungeonPhase phaseManager;
    public Calculation_Move moveController;
    public Battle_ObjectManager battleObjectManager;

    // Use this for initialization
    void Start()
    {
        aStar.Initialize(tileMap.GetComponent<Map_Main>().MapData);

        phaseManager.PhaseToExplore();

        battleObjectManager.Initialize();

        commonFeatures.Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FinishBattle()
    {
        phaseManager.PhaseToExplore();

        battleManager.gameObject.SetActive(false);
    }

    public void StartBattle(List<GameObject> enemiesInZone)
    {
        phaseManager.PhaseToBattle();

        battleManager.gameObject.SetActive(true);
        
        battleManager.GetComponent<Manager_Battle2>().Initialize(enemiesInZone);
    }
}
