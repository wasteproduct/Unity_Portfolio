using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Character;
using UnityEngine.UI;

public class Player_ToDungeon : MonoBehaviour
{
    public Player_Main playerMain;
    public Character_Database characterDatabase;

    public GameObject selectTeamFellowsPanel;
    public GameObject slotField;
    public GameObject slotPrefab;

    public GameObject slotCaptain;
    public GameObject[] slotFellow;

    private List<GameObject> characters = new List<GameObject>();

    //private bool characterSelected = false;
    private Character_Slot pickedSlot = null;

    public void SelectCharacter(Character_Slot selectedSlot)
    {
        CancelSelection();

        if (selectedSlot.TeamFellow == true)
        {
            selectedSlot.SetCharacterAddedAsTeam(false);

            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].GetComponent<Character_Slot>().highlightedFrame.gameObject.SetActive(false);
            }

            if (selectedSlot == slotCaptain.GetComponent<Player_TeamSlot>().AddedTeamFellowSlot)
            {
                slotCaptain.GetComponent<Player_TeamSlot>().Initialize();
                return;
            }
            for (int i = 0; i < slotFellow.Length; i++)
            {
                if (selectedSlot == slotFellow[i].GetComponent<Player_TeamSlot>().AddedTeamFellowSlot)
                {
                    slotFellow[i].GetComponent<Player_TeamSlot>().Initialize();
                    return;
                }
            }
        }
        else
        {
            pickedSlot = selectedSlot;
            //characterSelected = true;

            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].GetComponent<Character_Slot>().highlightedFrame.gameObject.SetActive(false);
            }

            HighlightTeamSlots(true);

            slotCaptain.GetComponent<Player_TeamSlot>().SetSelectedSlot(pickedSlot);
            for (int i = 0; i < slotFellow.Length; i++)
            {
                slotFellow[i].GetComponent<Player_TeamSlot>().SetSelectedSlot(pickedSlot);
            }

            ActivateTeamSlots(true);

            pickedSlot.highlightedFrame.gameObject.SetActive(true);
        }
    }

    //public void OpenSelectTeamFellows()
    //{
    //    selectTeamFellowsPanel.SetActive(true);

    //    playerMain.LoadData();

    //    CancelSelection();

    //    ClearPlayerTeam();

    //    for (int i = 0; i < playerMain.Characters.Count; i++)
    //    {
    //        if (playerMain.Characters[i] == null) continue;

    //        GameObject addedSlot = Instantiate<GameObject>(slotPrefab, slotField.transform);
    //        addedSlot.GetComponent<Character_Slot>().Initialize(playerMain.Characters[i], SelectCharacter);

    //        characters.Add(addedSlot);
    //    }

    //    InitializeTeamSlots();
    //}

    public void CancelSelectTeamFellows(bool editor)
    {
        CancelSelection();

        ClearCharacterSlotsList(editor);

        HighlightTeamSlots(false);

        selectTeamFellowsPanel.SetActive(false);
    }

    private void ClearPlayerTeam()
    {
        playerMain.playerTeam.captain = null;
        for (int i = 0; i < playerMain.playerTeam.teamFellow.Length; i++)
        {
            playerMain.playerTeam.teamFellow[i] = null;
        }
    }

    private void AddTeamFellow()
    {
        pickedSlot.SetCharacterAddedAsTeam(true);

        CancelSelection();

        HighlightTeamSlots(false);

        ActivateTeamSlots(false);
    }

    private void InitializeTeamSlots()
    {
        slotCaptain.GetComponent<Player_TeamSlot>().Initialize(AddTeamFellow);
        for (int i = 0; i < slotFellow.Length; i++)
        {
            slotFellow[i].GetComponent<Player_TeamSlot>().Initialize(AddTeamFellow);
        }

        ActivateTeamSlots(false);
    }

    private void ActivateTeamSlots(bool flag)
    {
        slotCaptain.GetComponent<Button>().interactable = flag;
        for (int i = 0; i < slotFellow.Length; i++)
        {
            slotFellow[i].GetComponent<Button>().interactable = flag;
        }
    }

    private void CancelSelection()
    {
        //characterSelected = false;
        pickedSlot = null;
    }

    private void ClearCharacterSlotsList(bool editor)
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
    }

    private void HighlightTeamSlots(bool on)
    {
        slotCaptain.GetComponent<Player_TeamSlot>().highlightedFrame.gameObject.SetActive(on);
        for (int i = 0; i < slotFellow.Length; i++)
        {
            slotFellow[i].GetComponent<Player_TeamSlot>().highlightedFrame.gameObject.SetActive(on);
        }
    }
}
