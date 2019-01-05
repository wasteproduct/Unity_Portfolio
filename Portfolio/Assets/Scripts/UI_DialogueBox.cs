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

    public void DisplayDialogueBox()
    {
        nPCName.text = eventNPCTalking.TalkingNPC.NPCName;
        dialogueContents.text = File.ReadAllText(Application.streamingAssetsPath + "/" + nPCName.text + ".txt");
    }
}
