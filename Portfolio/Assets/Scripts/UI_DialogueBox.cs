using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UI_DialogueBox : MonoBehaviour
{
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

    public void DisplayDialogueBox()
    {
        nPCName.text = eventNPCTalking.TalkingNPC.NPCName;

        if (eventNPCTalking.TalkingNPC.QuestGiven == true)
        {
            dialogueContents.text = File.ReadAllText(Application.streamingAssetsPath + "/" + nPCName.text + "NoQuest.txt");
            closeButtonText.text = "...";
        }
        else
        {
            acceptButton.gameObject.SetActive(true);
            dialogueContents.text = File.ReadAllText(Application.streamingAssetsPath + "/" + nPCName.text + ".txt");
            closeButtonText.text = "Sorry";
        }
    }
}
