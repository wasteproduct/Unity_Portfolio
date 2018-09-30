using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Player
{
    public class Player_OrganizeTeam : MonoBehaviour
    {
        public Player_Main playerMain;
        
        public Character_Database characterDatabase;

        public GameObject organizeTeamPanel;
        public GameObject slotField;

        public GameObject slotPrefab;

        public GameObject slotCaptain;
        public GameObject[] slotFellow;

        private List<GameObject> characters = new List<GameObject>();

        private bool characterSelected = false;
        private Character_Base pickedCharacter = null;

        public void SelectCharacter(Character_Base selectedCharacter)
        {
            CancelSelection();

            HighlightSlots();

            characterSelected = true;
            pickedCharacter = selectedCharacter;
        }

        public void OpenOrganizeTeam()
        {
            organizeTeamPanel.SetActive(true);

            playerMain.LoadData();

            SetCaptain();
            SetFellows();

            for (int i = 1; i < playerMain.Characters.Count; i++)
            {
                if (playerMain.Characters[i] == null) continue;

                GameObject addedSlot = Instantiate<GameObject>(slotPrefab, slotField.transform);
                addedSlot.GetComponent<Character_Slot>().Initialize(playerMain.Characters[i], SelectCharacter);

                characters.Add(addedSlot);
            }
        }

        public void CloseOrganizeTeam(bool editor)
        {
            if (editor == true)
            {
                for (int i = characters.Count - 1; i >= 0; i--)
                {
                    DestroyImmediate(characters[i].gameObject);
                }
            }
            else
            {
                for (int i = characters.Count - 1; i >= 0; i--)
                {
                    Destroy(characters[i].gameObject);
                }
            }

            characters.Clear();

            CancelSelection();

            organizeTeamPanel.SetActive(false);
        }

        private void SetFellows()
        {
            for (int i = 0; i < slotFellow.Length; i++)
            {
                slotFellow[i].GetComponent<Player_TeamSlot>().Initialize(playerMain.playerTeam.teamFellow[1]);
            }
        }

        private void HighlightSlots()
        {
            for (int i = 0; i < slotFellow.Length; i++)
            {
                slotFellow[i].GetComponent<Player_TeamSlot>().highlightedFrame.gameObject.SetActive(true);
            }
        }

        private void SetCaptain()
        {
            playerMain.playerTeam.teamFellow[0] = playerMain.Characters[0];

            slotCaptain.GetComponent<Player_TeamSlot>().Initialize(playerMain.playerTeam.teamFellow[0]);
        }

        private void CancelSelection()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].GetComponent<Character_Slot>().highlightedFrame.gameObject.SetActive(false);
            }

            for (int i = 0; i < slotFellow.Length; i++)
            {
                slotFellow[i].GetComponent<Player_TeamSlot>().highlightedFrame.gameObject.SetActive(false);
            }

            characterSelected = false;
            pickedCharacter = null;
        }

        // editor
        public int selectedCharacterIndex;

        public void SelectCharacter()
        {
            CancelSelection();

            if (organizeTeamPanel.activeSelf == false) return;

            if (IndexOutOfRange(selectedCharacterIndex, characters) == true) return;

            HighlightSlots();

            Character_Slot selectedSlot = characters[selectedCharacterIndex].GetComponent<Character_Slot>();
            selectedSlot.SelectCharacter();
        }

        private bool IndexOutOfRange(int index, List<GameObject> list)
        {
            if (index < 0) return true;
            if (index >= list.Count) return true;

            return false;
        }
    }
}
