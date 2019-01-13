using UnityEngine;
using Character;
using UnityEngine.UI;

public class UI_CharacterSlot : MonoBehaviour
{
    [SerializeField]
    private Image highlightFrame;
    [SerializeField]
    private Image characterPortrait;
    [SerializeField]
    private UI_CharacterStatus characterStatus;

    public Character_Base SlotCharacter { get; private set; }

    public void SelectSlot()
    {
        HighlightSlot(true);

        characterStatus.UpdateStatusValue(SlotCharacter);

        if (SlotCharacter.InstantiatedModel == null) return;
        SlotCharacter.InstantiatedModel.gameObject.SetActive(true);
    }

    public void SetSlot(Character_Base slotCharacter)
    {
        SlotCharacter = slotCharacter;

        characterPortrait.sprite = SlotCharacter.Portrait;
    }

    public void HighlightSlot(bool flag) { highlightFrame.gameObject.SetActive(flag); }
}
