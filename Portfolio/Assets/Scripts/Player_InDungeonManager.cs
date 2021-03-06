﻿using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player_InDungeonManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject portraitsPanel;
        [SerializeField]
        private GameObject portraitPrefab;
        [SerializeField]
        private UI_NoticingWindow noticingWindow;
        [SerializeField]
        private UI_DialogueBox dialogueBox;
        [SerializeField]
        private Manager_Inventory inventory;
        [SerializeField]
        private Event_SelectItem eventSelectItem;
        [SerializeField]
        private Manager_Quest questManager;

        public List<Character_InDungeonPortrait> PlayerCharacters { get; private set; }

        public void NPCTalking()
        {
            dialogueBox.gameObject.SetActive(true);
            dialogueBox.DisplayDialogueBox();
        }

        public void UseItem()
        {
            eventSelectItem.SelectedItem.UseItem();

            inventory.UseItem(eventSelectItem.SelectedSlotNumber);
        }

        public void DisableAll()
        {
            for (int i = 0; i < PlayerCharacters.Count; i++)
            {
                PlayerCharacters[i].HighlightPortrait(false);
            }
        }

        public void SelectItem()
        {
            for (int i = 0; i < PlayerCharacters.Count; i++)
            {
                PlayerCharacters[i].HighlightPortrait(true);
            }
        }

        public void GetNewItem()
        {
            noticingWindow.gameObject.SetActive(true);
            noticingWindow.ShowNewItem();
        }

        public void Initialize()
        {
            PlayerCharacters = new List<Character_InDungeonPortrait>();

            List<GameObject> playerCharacters = GetComponent<Player_DungeonSettings>().PlayerCharacters;

            for (int i = 0; i < playerCharacters.Count; i++)
            {
                GameObject newPortrait = Instantiate(portraitPrefab, portraitsPanel.transform);
                newPortrait.GetComponent<Character_InDungeonPortrait>().Initialize(playerCharacters[i]);

                PlayerCharacters.Add(newPortrait.GetComponent<Character_InDungeonPortrait>());
            }
        }
    }
}
