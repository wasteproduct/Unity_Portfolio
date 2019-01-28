using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Quest : MonoBehaviour
{
    [SerializeField]
    private Variable_Bool interactingUI;
    [SerializeField]
    private GameObject listPanel;
    [SerializeField]
    private Text questDetails;
    [SerializeField]
    private UI_QuestButton[] questButton;

    public UI_QuestButton SelectedQuestButton { get; set; }
    public List<Quest_Base> AcceptedQuest { get; private set; }

    public void FinishQuest()
    {
        for (int i = 0; i < AcceptedQuest.Count; i++)
        {
            Quest_Base completeQuest = AcceptedQuest[i];

            if (completeQuest == SelectedQuestButton.Quest)
            {
                completeQuest.FinishQuest();
                AcceptedQuest.Remove(completeQuest);
                // reward
                return;
            }
        }

        print("ERROR");
    }

    public void SelectQuest()
    {
        listPanel.gameObject.SetActive(false);

        questDetails.gameObject.SetActive(true);

        questDetails.text = SelectedQuestButton.Quest.QuestText;
        questDetails.text += "\n\n" + SelectedQuestButton.Quest.Objective;
    }

    public void AddQuest()
    {
        if (AcceptedQuest == null) AcceptedQuest = new List<Quest_Base>();

        SelectedQuestButton.Quest.Given(true);

        AcceptedQuest.Add(SelectedQuestButton.Quest);
    }

    public void Editor_GetButtons()
    {
        UI_QuestButton[] buttons = GetComponentsInChildren<UI_QuestButton>(true);

        for (int i = 0; i < questButton.Length; i++)
        {
            questButton[i] = buttons[i];
        }
    }

    private void OnDisable()
    {
        interactingUI.flag = false;

        for (int i = 0; i < questButton.Length; i++)
        {
            questButton[i].gameObject.SetActive(false);
        }

        SelectedQuestButton = null;
    }

    private void OnEnable()
    {
        if (AcceptedQuest == null) AcceptedQuest = new List<Quest_Base>();

        listPanel.gameObject.SetActive(true);

        questDetails.gameObject.SetActive(false);

        SelectedQuestButton = null;

        for (int i = 0; i < AcceptedQuest.Count; i++)
        {
            questButton[i].gameObject.SetActive(true);
            questButton[i].SetButton(AcceptedQuest[i]);
        }
    }
}
