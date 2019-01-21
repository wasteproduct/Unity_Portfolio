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
        private Tutorial_Soldier soldier;
        [SerializeField]
        private LayerMask layerTileMap;
        [SerializeField]
        private GameObject traceMark;
        [SerializeField]
        private Tutorial_TileMap_Current tileMap;

        private Tutorial_AStar aStar;
        private Tutorial_TileMap.Tutorial_Tile[,] tiles;
        private List<GameObject> trace;

        public void Run()
        {
            soldier.gameObject.transform.position += new Vector3(0, 0, 1);
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, 100.0f, layerTileMap))
                {
                    int x = (int)hitInfo.point.x;
                    int z = (int)hitInfo.point.z;

                    int soldierX = (int)soldier.gameObject.transform.position.x;
                    int soldierZ = (int)soldier.gameObject.transform.position.z;

                    aStar.FindPath(tiles, tiles[soldierX, soldierZ], tiles[x, z]);

                    ClearTraceMark();

                    List<Node_AStar> finalTrack = aStar.FinalTrack;

                    for (int i = 0; i < finalTrack.Count; i++)
                    {
                        trace.Add(Instantiate(traceMark, new Vector3(finalTrack[i].X, 0, finalTrack[i].Z), Quaternion.identity));
                    }
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

        private void Start()
        {
            // this is null
            print(tileMap.CurrentMap);
            tiles = tileMap.CurrentMap.Tiles;

            trace = new List<GameObject>();

            aStar = new Tutorial_AStar();
            aStar.Initialize(tileMap.CurrentMap);
        }
    }
}
