using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_AnimatorTest : MonoBehaviour
    {
        private Animator animator;

        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();

            animator.SetInteger("CurrentState", 2);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("grenade", true);
            }
        }
    }
}
