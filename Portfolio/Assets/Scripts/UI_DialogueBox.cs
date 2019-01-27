using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UI_DialogueBox : MonoBehaviour
{
    [SerializeField]
    private GameObject uIButtons;
    [SerializeField]
    private Variable_Bool interactingUI;
    [SerializeField]
    private Event_NPCTalking eventNPCTalking;
    [SerializeField]
    private Text nPCName;
    [SerializeField]
    private Text dialogueContents;
    [SerializeField]
    private Button_AcceptQuest okayButton;
    [SerializeField]
    private Button_Close declineButton;
    [SerializeField]
    private UI_QuestList questList;

    public void SetContents(string contents) { dialogueContents.text = contents; }

    public void FinishQuest()
    {
        eventNPCTalking.TalkingNPC.CallReaction();
    }

    public void DisplayDialogueBox()
    {
        Interactor_NPC talkingNPC = eventNPCTalking.TalkingNPC;

        nPCName.text = talkingNPC.NPCName;

        SetContents(File.ReadAllText(Application.streamingAssetsPath + "/" + nPCName.text + ".txt"));

        okayButton.gameObject.SetActive(false);

        declineButton.gameObject.SetActive(true);
        declineButton.SetButtonText("Bye");

        questList.gameObject.SetActive(true);
        questList.SetList(talkingNPC);
    }

    private void OnEnable()
    {
        uIButtons.gameObject.SetActive(false);
        interactingUI.flag = true;
    }

    private void OnDisable()
    {
        uIButtons.gameObject.SetActive(true);
        interactingUI.flag = false;
    }
}
