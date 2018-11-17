using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Boolean : MonoBehaviour
{
    public GameObject action;

    private bool NothingToDo { get { return action == null; } }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(NothingToDo);
        }
    }
}
