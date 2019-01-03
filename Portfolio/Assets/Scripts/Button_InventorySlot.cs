using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image selectedFrame;
    [SerializeField]
    private Event_SelectItem eventItemSelect;

    public Item_Base CorrespondingItem { get; private set; }

    public void Initialize()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    public void HighlightItem(bool flag)
    {
        selectedFrame.gameObject.SetActive(flag);
    }

    public void SelectItem()
    {
        eventItemSelect.SelectedItem = CorrespondingItem;
        eventItemSelect.Run();

        HighlightItem(true);
    }

    public void SetButton(Item_Base correspondingItem)
    {
        gameObject.GetComponent<Button>().interactable = true;

        CorrespondingItem = correspondingItem;

        GetComponent<Image>().sprite = CorrespondingItem.ItemImage;
    }
}
