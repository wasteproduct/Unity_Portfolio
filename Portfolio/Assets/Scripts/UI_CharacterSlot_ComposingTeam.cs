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

    public UI_TeamSlot RegisteredTeamSlot { get; private set; }
    public Character_Base SlotCharacter { get; private set; }
    public bool Drafted { get; private set; }

    public void Unregister()
    {
        RegisteredTeamSlot = null;
    }

    public void SelectSlot()
    {
        if (Drafted == true) SetDrafted(null, false);
        else HighlightSlot(true);
    }

    public void HighlightSlot(bool flag) { highlightFrame.gameObject.SetActive(flag); }

    public void SetDrafted(UI_TeamSlot teamSlot, bool flag)
    {
        RegisteredTeamSlot = teamSlot;
        draftedSign.gameObject.SetActive(flag);
        Drafted = flag;

        if (flag == true) HighlightSlot(false);
    }

    public void SetSlot(Character_Base slotCharacter)
    {
        RegisteredTeamSlot = null;
        SlotCharacter = slotCharacter;

        GetComponent<Image>().sprite = SlotCharacter.Portrait;

        SetDrafted(null, false);
        HighlightSlot(false);
    }
}
