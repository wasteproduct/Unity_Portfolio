using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image selectedFrame;
    [SerializeField]
    private Event_SelectItem eventSelectItem;

    public Item_Base CorrespondingItem { get; private set; }
    public int SlotNumber { get; private set; }

    public void Initialize(int slotNumber)
    {
        SlotNumber = slotNumber;
        CorrespondingItem = null;

        gameObject.GetComponent<Image>().sprite = null;
        gameObject.GetComponent<Button>().interactable = false;
    }

    public void HighlightItem(bool flag)
    {
        selectedFrame.gameObject.SetActive(flag);
    }

    public void SelectItem()
    {
        eventSelectItem.SelectedItem = CorrespondingItem;
        eventSelectItem.SelectedSlotNumber = SlotNumber;
        eventSelectItem.Run();

        HighlightItem(true);
    }

    public void SetButton(Item_Base correspondingItem)
    {
        gameObject.GetComponent<Button>().interactable = true;

        CorrespondingItem = correspondingItem;

        GetComponent<Image>().sprite = CorrespondingItem.ItemImage;
    }
}
