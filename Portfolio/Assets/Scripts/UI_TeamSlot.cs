using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TeamSlot : MonoBehaviour
{
    [SerializeField]
    private Image highlightFrame;

    public UI_CharacterSlot_ComposingTeam RegisteredCharacterSlot { get; private set; }

    public void SelectSlot()
    {

    }

    public void SetInteractable(bool flag)
    {
        highlightFrame.gameObject.SetActive(flag);
        GetComponent<Button>().interactable = flag;
    }
}
