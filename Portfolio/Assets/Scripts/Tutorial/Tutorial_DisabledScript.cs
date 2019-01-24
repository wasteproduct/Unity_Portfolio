using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_DisabledScript : MonoBehaviour
    {
        private int value;

        public int Value { get { return value; } }

        // Use this for initialization
        void Start()
        {
            value = 99;

            enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
