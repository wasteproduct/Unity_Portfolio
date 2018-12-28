using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_TreasureBox : Object_InteractorBase
{
    [SerializeField]
    private GameObject box;

    private Animator animator;

    public override void Interact()
    {
        animator.SetBool("Open", true);
    }

    // Use this for initialization
    void Start()
    {
        animator = box.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
