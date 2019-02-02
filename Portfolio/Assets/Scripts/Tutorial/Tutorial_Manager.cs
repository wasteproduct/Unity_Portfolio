using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

namespace Tutorial
{
    public class Tutorial_Manager : MonoBehaviour
    {
        [SerializeField]
        private Tutorial_AbstractClass_Base abstractClass;
        [SerializeField]
        private Tutorial_Soldier soldier;
        [SerializeField]
        private LayerMask layerTileMap;
        [SerializeField]
        private GameObject traceMark;
        [SerializeField]
        private Tutorial_TileMap tileMap;
        [SerializeField]
        private int mapPatternNumber;

        private Tutorial_AStar aStar;
        private Tutorial_TileMap.Tutorial_Tile[,] tiles;
        private List<GameObject> trace;

        public void Run()
        {
            List<int> runner = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                runner.Add(i);
            }

            print(runner.Count);

            for (int i = 0; i < 2; i++)
            {
                runner.Remove(i);
            }

            print(runner.Count);

            for (int i = 0; i < runner.Count; i++)
            {
                print(runner[i]);
            }
        }

        public void ResetMapData()
        {
            tiles = tileMap.Tiles;

            aStar.Initialize(tileMap);
        }

        private void Start()
        {
            tileMap.GenerateMap(mapPatternNumber);
            tiles = tileMap.Tiles;

            trace = new List<GameObject>();

            aStar = new Tutorial_AStar();
            aStar.Initialize(tileMap);
        }

        private void Update()
        {
            MoveSoldier();
            //Experiment();
        }

        private void Experiment()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                abstractClass.IncreaseValue();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                print(abstractClass.Value);
            }
        }

        private void MoveSoldier()
        {
            if (soldier.Moving == true) return;

            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, 100.0f, layerTileMap))
                {
                    int x = (int)(hitInfo.point.x + .5f);
                    int z = (int)(hitInfo.point.z + .5f);

                    int soldierX = (int)soldier.gameObject.transform.position.x;
                    int soldierZ = (int)soldier.gameObject.transform.position.z;

                    bool pathFound = aStar.FindPath(tiles, tiles[soldierX, soldierZ], tiles[x, z]);

                    if (pathFound == false)
                    {
                        print("Failed to find path.");
                        return;
                    }

                    ClearTraceMark();

                    List<Node_AStar> finalTrack = aStar.FinalTrack;

                    for (int i = 0; i < finalTrack.Count; i++)
                    {
                        trace.Add(Instantiate(traceMark, new Vector3(finalTrack[i].X, 0, finalTrack[i].Z), Quaternion.identity));
                    }

                    StartCoroutine(soldier.Move(finalTrack, ClearTraceMark));
                }
            }
        }

        private void ClearTraceMark()
        {
            for (int i = 0; i < trace.Count; i++)
            {
                Destroy(trace[i]);
            }
            trace.Clear();
        }
    }
}
