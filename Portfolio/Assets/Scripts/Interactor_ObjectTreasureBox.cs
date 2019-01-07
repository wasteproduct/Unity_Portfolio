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

        clickEvent.interactorTile.Type = TileDataSet.TileType.Floor;
    }

    public override void Interact()
    {
        animator.SetBool("Open", true);

        clickEvent.interactorClicked = false;
    }
}
