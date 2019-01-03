using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image selectedFrame;

    public Item_Base CorrespondingItem { get; private set; }

    public void SelectItem()
    {
        selectedFrame.gameObject.SetActive(true);
    }

    public void SetButton(Item_Base correspondingItem)
    {
        CorrespondingItem = correspondingItem;

        GetComponent<Image>().sprite = CorrespondingItem.ItemImage;
    }
}
