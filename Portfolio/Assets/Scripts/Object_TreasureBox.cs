using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_TreasureBox : Object_InteractorBase
{
    [SerializeField]
    private GameObject box;
    [SerializeField]
    private Event_Click clickEvent;
    [SerializeField]
    private Interactor_ReactionBase[] interactorReaction;

    private Animator animator;

    public override void CallReaction()
    {
        int reactionNumber = Random.Range(0, interactorReaction.Length);

        for (int i = 0; i < interactorReaction.Length; i++)
        {
            if (i == reactionNumber)
            {
                interactorReaction[i].InteractorReacts(this);
                return;
            }
        }
    }

    public override void Interact()
    {
        animator.SetBool("Open", true);

        clickEvent.interactorClicked = false;
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
