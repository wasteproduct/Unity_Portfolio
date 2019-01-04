using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_AnimatorTest : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) animator.SetInteger("CurrentState", 1);
            if (Input.GetKeyDown(KeyCode.Alpha2)) animator.SetInteger("CurrentState", 2);
        }
    }
}
