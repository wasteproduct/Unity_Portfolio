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

    public Quest_Base Quest { get; private set; }

    public void SelectQuest()
    {
        dialogueBox.SetContents(Quest.QuestText);

        declineButton.SetButtonText("Sorry");

        questManager.SelectedQuestButton = this;
    }

    public void SetButton(Quest_Base quest)
    {
        Quest = quest;
        Quest.Given(true);

        questName.text = Quest.QuestName;
    }
}
