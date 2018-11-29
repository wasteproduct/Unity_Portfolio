using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_ValidityTest : MonoBehaviour
    {
        public Character_State actionState;
        public GameObject inactiveState;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                bool valid = (inactiveState.GetComponent<Tutorial_InactiveState>().attackState == actionState) ? true : false;

                print(valid);
            }
        }
    }
}
