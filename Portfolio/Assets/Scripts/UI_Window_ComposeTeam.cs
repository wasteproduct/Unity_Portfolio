using System.Collections.Generic;
using UnityEngine;
using Character;
using Player;

public class UI_Window_ComposeTeam : UI_Window_Base
{
    [SerializeField]
    private Player_Main playerMain;
    [SerializeField]
    private UI_CharacterStatus characterStatus;
    [SerializeField]
    private UI_TeamSlot[] teamSlots;
    [SerializeField]
    private UI_CharacterSlot_ComposingTeam[] characterSlots;

    public UI_CharacterSlot_ComposingTeam SelectedCharacterSlot { get; private set; }
    public UI_TeamSlot[] TeamSlots { get { return teamSlots; } }

    public void SelectTeamSlot(UI_TeamSlot selectedSlot)
    {
        SelectedCharacterSlot.SetDrafted(selectedSlot, true);

        for (int i = 0; i < teamSlots.Length; i++)
        {
            teamSlots[i].SetInteractable(false);
        }
    }

    public void SelectCharacterSlot(UI_CharacterSlot_ComposingTeam selectedSlot)
    {
        if (selectedSlot.Drafted == true)
        {
            selectedSlot.RegisteredTeamSlot.Unregister();

            return;
        }

        for (int i = 0; i < characterSlots.Length; i++)
        {
            if (characterSlots[i].gameObject.activeSelf == false) continue;

            characterSlots[i].HighlightSlot(false);

            if (characterSlots[i].SlotCharacter.InstantiatedModel == null) continue;
            characterSlots[i].SlotCharacter.InstantiatedModel.gameObject.SetActive(false);
        }

        for (int i = 0; i < teamSlots.Length; i++)
        {
            teamSlots[i].SetInteractable(true);
        }

        SelectedCharacterSlot = selectedSlot;

        characterStatus.UpdateStatusValue(selectedSlot.SlotCharacter);
    }

    public void Editor_GetSlots()
    {
        UI_CharacterSlot_ComposingTeam[] slots = GetComponentsInChildren<UI_CharacterSlot_ComposingTeam>(true);

        for (int i = 0; i < slots.Length; i++)
        {
            characterSlots[i] = slots[i];
        }

        UI_TeamSlot[] slots2 = GetComponentsInChildren<UI_TeamSlot>(true);

        for (int i = 0; i < slots2.Length; i++)
        {
            teamSlots[i] = slots2[i];
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < teamSlots.Length; i++)
        {
            teamSlots[i].Unregister();
            teamSlots[i].SetInteractable(false);
        }

        characterStatus.ClearValues();

        for (int i = 0; i < characterSlots.Length; i++)
        {
            if (characterSlots[i].gameObject.activeSelf == false) continue;

            characterSlots[i].SlotCharacter.InstantiatedModel.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        List<Character_Base> playerCharacters = playerMain.Characters;

        for (int i = 0; i < playerCharacters.Count; i++)
        {
            characterSlots[i].gameObject.SetActive(true);
            characterSlots[i].SetSlot(playerCharacters[i]);
        }

        SelectedCharacterSlot = null;
    }
}
