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
            offset = new Vector3(0, 1.6f, 3.2f);

            this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.position = focus.gameObject.transform.position + offset;
        }
    }
}
