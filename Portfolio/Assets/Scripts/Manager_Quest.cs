using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Quest : MonoBehaviour
{
    [SerializeField]
    private Variable_Bool interactingUI;
    [SerializeField]
    private Event_NPCTalking eventNPCTalking;
    [SerializeField]
    private Text[] quest;

    public List<Interactor_NPCAcquireChan> Clients = new List<Interactor_NPCAcquireChan>();

    public void AddQuest()
    {
        Clients.Add(eventNPCTalking.TalkingNPC);
    }

    private void OnDisable()
    {
        interactingUI.flag = false;
    }

    private void OnEnable()
    {
        for (int i = 0; i < Clients.Count; i++)
        {
            quest[i].text = Clients[i].NPCQuest.QuestText.text;
        }
    }
}
