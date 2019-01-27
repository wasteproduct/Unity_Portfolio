using System.Collections.Generic;
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

    public Quest_Base[] GetDisplayedQuests()
    {
        List<Quest_Base> result = new List<Quest_Base>();

        for (int i = 0; i < NPCQuest.Length; i++)
        {
            if (NPCQuest[i].QuestComplete == true) continue;

            if (NPCQuest[i].QuestGiven == false) result.Add(NPCQuest[i]);
            else
            {
                if (NPCQuest[i].ProgressionComplete() == false) continue;

                result.Add(NPCQuest[i]);
            }
        }

        return result.ToArray();
    }

    public Quest_Base[] GetUnassignedQuests()
    {
        List<Quest_Base> result = new List<Quest_Base>();

        for (int i = 0; i < NPCQuest.Length; i++)
        {
            if (NPCQuest[i].QuestGiven == true) continue;

            result.Add(NPCQuest[i]);
        }

        return result.ToArray();
    }

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

    private void Start()
    {
        for (int i = 0; i < nPCQuest.Length; i++)
        {
            nPCQuest[i].Given(false);
        }
    }
}
