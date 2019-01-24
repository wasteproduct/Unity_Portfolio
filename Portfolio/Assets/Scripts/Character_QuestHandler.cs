using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_QuestHandler : MonoBehaviour
{
    [SerializeField]
    private Quest_Base[] relevantQuests;

    public void UpdateQuestProgression()
    {
        for (int i = 0; i < relevantQuests.Length; i++)
        {
            if (relevantQuests[i].QuestGiven == false) continue;

            relevantQuests[i].UpdateProgression();
        }
    }
}
