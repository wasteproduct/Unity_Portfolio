using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_HealthBar : MonoBehaviour
    {
        private Quaternion lookRotation;

        // Use this for initialization
        void Start()
        {
            Vector3 forward = Camera.main.transform.position - transform.position;
            forward.Normalize();

            lookRotation = Quaternion.LookRotation(forward, Vector3.up);
        }

        // Update is called once per frame
        void Update()
        {
            //transform.LookAt(Camera.main.transform.position, Vector3.up);
            transform.rotation = lookRotation;
        }
    }
}
