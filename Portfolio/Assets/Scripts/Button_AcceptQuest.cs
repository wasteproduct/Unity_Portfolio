using UnityEngine;

public class Button_AcceptQuest : MonoBehaviour
{
    [SerializeField]
    private Manager_Quest questManager;
    [SerializeField]
    private Event_NPCTalking eventNPCTalking;

    public void AcceptQuest()
    {
        questManager.AddQuest();
        eventNPCTalking.TalkingNPC.CallReaction();

        gameObject.SetActive(false);
    }
}
