using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Base : ScriptableObject
{
    [SerializeField]
    protected string itemName;
    [SerializeField]
    protected string itemDescription;
    [SerializeField]
    protected Sprite itemImage;
    [SerializeField]
    protected Item_ID iD;
    [SerializeField]
    protected Player.Player_Inventory inventory;
    [SerializeField]
    protected Event_GetItem eventGetItem;
    [SerializeField]
    protected Event_UseItem eventUseItem;
    [SerializeField]
    protected Event_SelectItem eventSelectItem;

    public string ItemName { get { return itemName; } }
    public string ItemDescription { get { return itemDescription; } }
    public Sprite ItemImage { get { return itemImage; } }

    public abstract void GetNewItem();
    public abstract void UseItem();
}
