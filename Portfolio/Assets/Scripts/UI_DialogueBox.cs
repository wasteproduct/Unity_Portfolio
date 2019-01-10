using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UI_DialogueBox : MonoBehaviour
{
    [SerializeField]
    private Variable_Bool interactingUI;
    [SerializeField]
    private Event_NPCTalking eventNPCTalking;
    [SerializeField]
    private Text nPCName;
    [SerializeField]
    private Text dialogueContents;
    [SerializeField]
    private Button acceptButton;
    [SerializeField]
    private Text closeButtonText;
    [SerializeField]
    private UI_QuestList questList;

    public void DisplayDialogueBox()
    {
        Interactor_NPC talkingNPC = eventNPCTalking.TalkingNPC;

        nPCName.text = talkingNPC.NPCName;

        dialogueContents.text = File.ReadAllText(Application.streamingAssetsPath + "/" + nPCName.text + ".txt");

        closeButtonText.text = "Bye";

        questList.SetList(talkingNPC);
    }

    private void OnEnable()
    {
        interactingUI.flag = true;
    }

    private void OnDisable()
    {
        interactingUI.flag = false;
    }
}
