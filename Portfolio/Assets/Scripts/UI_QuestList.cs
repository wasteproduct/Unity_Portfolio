using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_QuestList : MonoBehaviour
{
    [SerializeField]
    private UI_QuestButton[] questButton;

    public void SetList(Interactor_NPC talkingNPC)
    {
        for (int i = 0; i < questButton.Length; i++)
        {
            for (int j = 0; j < talkingNPC.NPCQuest.Length; j++)
            {
                Quest_Base quest = talkingNPC.NPCQuest[j];

                if (quest.QuestGiven == true) continue;

                questButton[i].SetButton(quest);
            }
        }
    }
}
