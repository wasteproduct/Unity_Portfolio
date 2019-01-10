using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Event/NPC Talking", order = 1)]
public class Event_NPCTalking : CustomEvent
{
    public Interactor_NPC TalkingNPC { get; set; }
}
