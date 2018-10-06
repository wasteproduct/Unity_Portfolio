using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Boolean : MonoBehaviour
{
    public bool PlayerTurn { get; private set; }
    public bool EnemyTurn { get; private set; }

    // Use this for initialization
    void Start()
    {
        PlayerTurn = true;
        EnemyTurn = false;

        print("Player Turn : " + PlayerTurn);
        print("Enemy Turn : " + EnemyTurn);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTurn = !PlayerTurn;
            EnemyTurn = !EnemyTurn;

            print("Player Turn : " + PlayerTurn);
            print("Enemy Turn : " + EnemyTurn);
        }
    }
}
