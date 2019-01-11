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

    public void SelectQuest(bool interactingNPC)
    {
        questManager.SelectedQuestButton = this;

        if (interactingNPC == false) return;

        ModifyDialogueBox();
    }

    public void SetButton(Quest_Base quest)
    {
        Quest = quest;

        questName.text = Quest.QuestName;
    }

    private void ModifyDialogueBox()
    {
        dialogueBox.SetContents(Quest.QuestText);

        declineButton.SetButtonText("Sorry");
    }
}
