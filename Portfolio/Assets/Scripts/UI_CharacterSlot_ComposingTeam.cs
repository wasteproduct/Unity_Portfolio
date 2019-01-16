using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using UnityEngine.UI;

public class UI_CharacterSlot_ComposingTeam : MonoBehaviour
{
    [SerializeField]
    private Image highlightFrame;
    [SerializeField]
    private Image draftedSign;

    public Character_Base SlotCharacter { get; private set; }
    public bool Drafted { get; private set; }

    public void SelectSlot()
    {
        if (Drafted == true)
        {
            SetDrafted(false);
        }
        else
        {
            HighlightSlot(true);
        }
    }

    public void HighlightSlot(bool flag) { highlightFrame.gameObject.SetActive(flag); }

    public void SetDrafted(bool flag)
    {
        draftedSign.gameObject.SetActive(flag);
        Drafted = flag;
    }

    public void SetSlot(Character_Base slotCharacter)
    {
        SlotCharacter = slotCharacter;

        GetComponent<Image>().sprite = SlotCharacter.Portrait;

        SetDrafted(false);
        HighlightSlot(false);
    }
}
