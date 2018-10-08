using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerDungeonSettings : MonoBehaviour
{
    public GameObject testCharacter;
    public Variable_Int currentTileX;
    public Variable_Int currentTileZ;
    public Variable_Int mouseX;
    public Variable_Int mouseZ;

    public GameObject CameraFocus { get; private set; }

    // Use this for initialization
    void Start()
    {
        CameraFocus = Instantiate<GameObject>(testCharacter, new Vector3((float)currentTileX.value, 0.0f, (float)currentTileZ.value), Quaternion.identity);
        print(currentTileX.value + ", " + currentTileZ.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(mouseX.value + ", " + mouseZ.value);
        }
    }
}
