using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Character;

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

    private bool characterSelected = false;
    private Character_Base pickedCharacter = null;

    public void SelectCharacter(Character_Base selectedCharacter)
    {
        CancelSelection();

        pickedCharacter = selectedCharacter;
        characterSelected = true;

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].GetComponent<Character_Slot>().highlightedFrame.gameObject.SetActive(false);
        }

        HighlightTeamSlots(true);

        slotCaptain.GetComponent<Player_TeamSlot>().SetSelectedCharacter(pickedCharacter);
        for (int i = 0; i < slotFellow.Length; i++)
        {
            slotFellow[i].GetComponent<Player_TeamSlot>().SetSelectedCharacter(pickedCharacter);
        }
    }

    public void OpenSelectTeamFellows()
    {
        selectTeamFellowsPanel.SetActive(true);

        playerMain.LoadData();

        CancelSelection();

        for (int i = 0; i < playerMain.Characters.Count; i++)
        {
            if (playerMain.Characters[i] == null) continue;

            GameObject addedSlot = Instantiate<GameObject>(slotPrefab, slotField.transform);
            addedSlot.GetComponent<Character_Slot>().Initialize(playerMain.Characters[i], SelectCharacter);

            characters.Add(addedSlot);
        }

        InitializeTeamSlots();
    }

    public void CancelSelectTeamFellows(bool editor)
    {
        CancelSelection();

        ClearCharacterSlotsList(editor);

        HighlightTeamSlots(false);

        selectTeamFellowsPanel.SetActive(false);
    }

    // 여기
    private void InitializeTeamSlots()
    {
        //slotCaptain.GetComponent<Player_TeamSlot>().Initialize(AddTeamFellow);
        for (int i = 0; i < slotFellow.Length; i++)
        {
            //slotFellow[i].GetComponent<Player_TeamSlot>().Initialize(AddTeamFellow);
        }
    }

    private void AddTeamFellow(Character_Base selectedCharacter)
    {

    }

    private void CancelSelection()
    {
        characterSelected = false;
        pickedCharacter = null;
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
