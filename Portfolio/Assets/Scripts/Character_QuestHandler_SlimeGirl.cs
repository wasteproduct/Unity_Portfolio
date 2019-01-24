using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_QuestHandler_SlimeGirl : Character_QuestHandler_Base
{
    [SerializeField]
    private Event_KillSlimeGirl eventKillSlimeGirl;

    public override void ProgressQuest()
    {
        eventKillSlimeGirl.Run();
    }
}
