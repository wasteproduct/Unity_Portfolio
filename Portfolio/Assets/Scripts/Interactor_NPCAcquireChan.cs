using UnityEngine;

public class Interactor_NPCAcquireChan : Interactor_Base
{
    [SerializeField]
    private Quest_Base nPCQuest;
    [SerializeField]
    private Event_NPCTalking eventNPCTalking;
    [SerializeField]
    private string nPCName;
    [SerializeField]
    private bool questGiven = false;

    public string NPCName { get { return nPCName; } }
    public bool QuestGiven { get { return questGiven; } }
    public Quest_Base NPCQuest { get { return nPCQuest; } }

    public override void CallReaction()
    {
        animator.SetInteger("CurrentState", 2);

        questGiven = true;
    }

    public override void Interact()
    {
        animator.SetInteger("CurrentState", 1);

        clickEvent.interactorClicked = false;

        eventNPCTalking.TalkingNPC = this;
        eventNPCTalking.Run();
    }
}
