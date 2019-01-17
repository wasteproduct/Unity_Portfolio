using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TeamSlot : MonoBehaviour
{
    [SerializeField]
    private Sprite slotSprite;
    [SerializeField]
    private Image highlightFrame;

    public UI_CharacterSlot_ComposingTeam RegisteredCharacterSlot { get; private set; }

    public void Unregister()
    {
        RegisteredCharacterSlot = null;

        GetComponent<Image>().sprite = slotSprite;
    }

    public void SelectSlot(UI_Window_ComposeTeam teamComposer)
    {
        if (RegisteredCharacterSlot != null) RegisteredCharacterSlot.SetDrafted(null, false);

        RegisteredCharacterSlot = teamComposer.SelectedCharacterSlot;

        GetComponent<Image>().sprite = RegisteredCharacterSlot.SlotCharacter.Portrait;
    }

    public void SetInteractable(bool flag)
    {
        highlightFrame.gameObject.SetActive(flag);
        GetComponent<Button>().interactable = flag;
    }
}
