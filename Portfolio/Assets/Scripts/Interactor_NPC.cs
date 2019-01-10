using UnityEngine;

public class Interactor_NPC : Interactor_Base
{
    [SerializeField]
    private Event_NPCTalking eventNPCTalking;
    [SerializeField]
    private string nPCName;
    [SerializeField]
    private Quest_Base[] nPCQuest;

    public string NPCName { get { return nPCName; } }
    public Quest_Base[] NPCQuest { get { return nPCQuest; } }

    public override void CallReaction()
    {
        animator.SetInteger("CurrentState", 2);
    }

    public override void Interact()
    {
        animator.SetInteger("CurrentState", 1);

        clickEvent.interactorClicked = false;

        eventNPCTalking.TalkingNPC = this;
        eventNPCTalking.Run();
    }
}
