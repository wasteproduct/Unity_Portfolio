using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Character;
using Player;

public class UI_Window_ComposeTeam : UI_Window_Base
{
    [SerializeField]
    private Player_Main playerMain;
    [SerializeField]
    private UI_CharacterSlot_ComposingTeam[] characterSlots;

    public void SelectSlot()
    {
        //for (int i = 0; i < characterSlots.Length; i++)
        //{
        //    if (characterSlots[i].gameObject.activeSelf == false) continue;

        //    characterSlots[i].HighlightSlot(false);

        //    if (characterSlots[i].SlotCharacter.InstantiatedModel == null) continue;
        //    characterSlots[i].SlotCharacter.InstantiatedModel.gameObject.SetActive(false);
        //}
    }

    public void Editor_GetSlots()
    {
        UI_CharacterSlot_ComposingTeam[] slots = GetComponentsInChildren<UI_CharacterSlot_ComposingTeam>(true);

        for (int i = 0; i < slots.Length; i++)
        {
            characterSlots[i] = slots[i];
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
    }
}
