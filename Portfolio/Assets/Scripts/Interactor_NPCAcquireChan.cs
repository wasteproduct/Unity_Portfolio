using UnityEngine;

public class Interactor_NPCAcquireChan : Interactor_Base
{
    [SerializeField]
    private Event_NPCTalking eventNPCTalking;
    [SerializeField]
    private string nPCName;

    public string NPCName { get { return nPCName; } }

    public override void CallReaction()
    {

    }

    public override void Interact()
    {
        animator.SetInteger("CurrentState", 1);

        clickEvent.interactorClicked = false;

        eventNPCTalking.TalkingNPC = this;
        eventNPCTalking.Run();
    }
}
