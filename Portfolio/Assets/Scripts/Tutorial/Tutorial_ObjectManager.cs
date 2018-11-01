using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_ObjectManager : MonoBehaviour
    {
        public GameObject markPrefab;

        private GameObject mark;

        // Use this for initialization
        void Start()
        {
            mark = Instantiate(markPrefab);
        }

        // Update is called once per frame
        void Update()
        {
            mark.transform.Rotate(0, 256.0f * Time.deltaTime, 0);
        }
    }
}
