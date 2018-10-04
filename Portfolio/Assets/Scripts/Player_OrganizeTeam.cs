using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using UnityEngine.UI;

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

            for (int i = 0; i < slotFellow.Length; i++)
            {
                slotFellow[i].GetComponent<Button>().interactable = true;
                //slotFellow[i].GetComponent<Player_TeamSlot>().SetSelectedCharacter(pickedCharacter);
            }
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
                //addedSlot.GetComponent<Character_Slot>().Initialize(playerMain.Characters[i], SelectCharacter);

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

        public void AddTeamFellow(Character_Base selectedCharacter, int slotIndex)
        {
            playerMain.playerTeam.teamFellow[slotIndex] = selectedCharacter;
            CancelSelection();
        }

        private void SetFellows()
        {
            for (int i = 0; i < slotFellow.Length; i++)
            {
                //slotFellow[i].GetComponent<Player_TeamSlot>().Initialize(playerMain.playerTeam.teamFellow[i], AddTeamFellow);
            }
        }

        private void HighlightSlots()
        {
            for (int i = 0; i < slotFellow.Length; i++)
            {
                //slotFellow[i].GetComponent<Player_TeamSlot>().highlightedFrame.gameObject.SetActive(true);
            }
        }

        private void SetCaptain()
        {
            playerMain.playerTeam.captain = playerMain.Characters[0];

            //slotCaptain.GetComponent<Player_TeamSlot>().Initialize(playerMain.playerTeam.captain, AddTeamFellow);
        }

        private void CancelSelection()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].GetComponent<Character_Slot>().highlightedFrame.gameObject.SetActive(false);
            }

            for (int i = 0; i < slotFellow.Length; i++)
            {
                //slotFellow[i].GetComponent<Player_TeamSlot>().highlightedFrame.gameObject.SetActive(false);
                slotFellow[i].GetComponent<Button>().interactable = false;
            }

            characterSelected = false;
            pickedCharacter = null;
        }

        // editor
        public int selectedCharacterIndex;
        public int selectedSlotIndex;

        public void AddTeamFellow()
        {
            if (organizeTeamPanel.activeSelf == false) return;

            if (IndexOutOfRange(selectedSlotIndex, 3) == true) return;

            playerMain.playerTeam.teamFellow[selectedSlotIndex] = pickedCharacter;

            for (int i = 0; i < characterDatabase.Portraits.Count; i++)
            {
                if (pickedCharacter.TypeID == characterDatabase.Portraits[i].typeID)
                {
                    slotFellow[selectedSlotIndex].GetComponent<Image>().sprite = characterDatabase.Portraits[i].image;
                    break;
                }
            }

            CancelSelection();
        }

        public void SelectCharacter()
        {
            CancelSelection();

            if (organizeTeamPanel.activeSelf == false) return;

            if (IndexOutOfRange(selectedCharacterIndex, characters.Count) == true) return;

            HighlightSlots();

            Character_Slot selectedSlot = characters[selectedCharacterIndex].GetComponent<Character_Slot>();
            selectedSlot.SelectCharacter();
        }

        private bool IndexOutOfRange(int index, int listCount)
        {
            if (index < 0) return true;
            if (index >= listCount) return true;

            return false;
        }
    }
}
