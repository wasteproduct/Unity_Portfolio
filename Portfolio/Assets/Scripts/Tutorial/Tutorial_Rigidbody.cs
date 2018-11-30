using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_Rigidbody : MonoBehaviour
    {
        private Rigidbody rigidbody;

        // Use this for initialization
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Vector3 jumping = Vector3.up + transform.forward;
                jumping.Normalize();

                rigidbody.AddForce(jumping * 4, ForceMode.Impulse);
            }
        }
    }
}
