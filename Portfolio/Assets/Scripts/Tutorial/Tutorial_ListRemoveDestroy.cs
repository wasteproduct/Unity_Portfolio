using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_ListRemoveDestroy : MonoBehaviour
{
    public GameObject objectPrefab;

    private List<GameObject> prefabs = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        ClearPrefabs();

        for (int z = 0; z < 5; z++)
        {
            for (int x = 0; x < 5; x++)
            {
                GameObject newObject = Instantiate<GameObject>(objectPrefab, new Vector3((float)x, 0.0f, (float)z), Quaternion.identity);

                prefabs.Add(newObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClearPrefabs();

            int zMax = Random.Range(1, 6);
            int xMax = Random.Range(1, 6);

            for (int z = 0; z < zMax; z++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    GameObject newObject = Instantiate<GameObject>(objectPrefab, new Vector3((float)x, 0.0f, (float)z), Quaternion.identity);

                    prefabs.Add(newObject);
                }
            }
        }
    }

    private void ClearPrefabs()
    {
        for (int i = prefabs.Count - 1; i >= 0; i--)
        {
            Destroy(prefabs[i].gameObject);

            prefabs.RemoveAt(i);
        }

        prefabs.Clear();
    }
}
