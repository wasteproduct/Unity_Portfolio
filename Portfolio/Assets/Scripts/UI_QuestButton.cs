using UnityEngine;
using UnityEngine.UI;

public class UI_QuestButton : MonoBehaviour
{
    [SerializeField]
    private Text questName;
    [SerializeField]
    private UI_DialogueBox dialogueBox;
    [SerializeField]
    private Button_Close declineButton;
    [SerializeField]
    private Manager_Quest questManager;
    [SerializeField]
    private Image completeMark;
    [SerializeField]
    private Button_AcceptQuest buttonAcceptQuest;
    [SerializeField]
    private UI_Button_FinishQuest buttonFinishQuest;

    public Quest_Base Quest { get; private set; }

    public void SelectQuest(bool interactingNPC)
    {
        questManager.SelectedQuestButton = this;

        if (interactingNPC == false) return;

        UpdateDialogueBox();
    }

    public void SetButton(Quest_Base quest)
    {
        Quest = quest;

        questName.text = Quest.QuestName;

        completeMark.gameObject.SetActive(Quest.ProgressionComplete());

        if (Quest.QuestGiven == false) completeMark.gameObject.SetActive(false);
    }

    private void UpdateDialogueBox()
    {
        dialogueBox.SetContents(Quest.QuestText);

        // 이미 받은, 완료한 퀘스트를 클릭
        if (Quest.QuestGiven == true)
        {
            if (Quest.ProgressionComplete() == true)
            {
                declineButton.gameObject.SetActive(false);
                buttonFinishQuest.gameObject.SetActive(true);
            }
        }
        // 새로 받을 퀘스트를 클릭
        else
        {
            buttonAcceptQuest.gameObject.SetActive(true);
            declineButton.SetButtonText("Sorry");
        }
    }
}
