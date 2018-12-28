using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_TreasureBox : MonoBehaviour
{
    [SerializeField]
    private GameObject box;

    private Animator animator;

    public void OpenBox()
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
