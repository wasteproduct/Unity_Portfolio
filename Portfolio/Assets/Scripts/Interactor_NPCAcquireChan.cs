using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor_NPCAcquireChan : Interactor_Base
{
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
        animator.SetInteger("CurrentState", 1);

        clickEvent.interactorClicked = false;
    }
}
