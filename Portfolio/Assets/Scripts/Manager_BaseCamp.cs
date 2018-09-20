using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Manager_BaseCamp : MonoBehaviour
{
    public Player_Main playerMain;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(playerMain.Characters.Count);
        }
    }
}
