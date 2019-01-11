using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_QuestList : MonoBehaviour
{
    [SerializeField]
    private UI_QuestButton[] questButton;

    public void SetList(Interactor_NPC talkingNPC)
    {
        Quest_Base[] unassignedQuests = talkingNPC.GetUnassignedQuests();

        for (int i = 0; i < unassignedQuests.Length; i++)
        {
            questButton[i].gameObject.SetActive(true);
            questButton[i].SetButton(unassignedQuests[i]);
        }
    }

    public void Editor_GetButtons()
    {
        UI_QuestButton[] buttons = GetComponentsInChildren<UI_QuestButton>(true);

        for (int i = 0; i < questButton.Length; i++) { questButton[i] = buttons[i]; }
    }

    private void OnDisable()
    {
        for (int i = 0; i < questButton.Length; i++)
        {
            questButton[i].gameObject.SetActive(false);
        }
    }
}
