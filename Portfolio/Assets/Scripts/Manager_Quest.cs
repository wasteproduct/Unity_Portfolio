using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Quest : MonoBehaviour
{
    [SerializeField]
    private Variable_Bool interactingUI;
    [SerializeField]
    private UI_QuestButton[] questButton;

    public UI_QuestButton SelectedQuestButton { get; set; }
    public List<Quest_Base> AcceptedQuest { get; private set; }

    public void AddQuest()
    {
        AcceptedQuest.Add(SelectedQuestButton.Quest);
    }

    private void OnDisable()
    {
        SelectedQuestButton = null;
        interactingUI.flag = false;
    }

    private void OnEnable()
    {
        SelectedQuestButton = null;

        for (int i = 0; i < AcceptedQuest.Count; i++)
        {

        }
    }

    private void Start()
    {
        SelectedQuestButton = null;
        AcceptedQuest = new List<Quest_Base>();
    }
}
