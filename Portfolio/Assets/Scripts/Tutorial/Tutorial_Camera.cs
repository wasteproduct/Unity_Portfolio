using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_Camera : MonoBehaviour
    {
        public GameObject focus;

        private Vector3 offset;

        // Use this for initialization
        void Start()
        {
            offset = new Vector3(-8.0f, 8.0f, -8.0f);

            transform.rotation = Quaternion.Euler(30.0f, 45.0f, 0.0f);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = focus.gameObject.transform.position + offset;
        }
    }
}
