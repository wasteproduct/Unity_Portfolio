using UnityEngine;

public class Interactor_ObjectTreasureBox : Interactor_Base
{
    public override void CallReaction()
    {
        int reactionNumber = Random.Range(0, interactorReaction.Length);

        for (int i = 0; i < interactorReaction.Length; i++)
        {
            if (i == reactionNumber)
            {
                interactorReaction[i].InteractorReacts(this);
                break;
            }
        }
    }

    public override void Interact()
    {
        animator.SetBool("Open", true);

        clickEvent.interactorClicked = false;
    }
}
