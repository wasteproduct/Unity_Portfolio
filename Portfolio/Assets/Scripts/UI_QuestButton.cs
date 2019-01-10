using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestButton : MonoBehaviour
{
    [SerializeField]
    private Text questName;

    public void SetButton(Quest_Base quest)
    {
        questName.text = quest.QuestName;
    }
}
