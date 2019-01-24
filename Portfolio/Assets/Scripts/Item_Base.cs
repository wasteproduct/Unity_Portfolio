using UnityEngine;

public abstract class Item_Base : ScriptableObject
{
    [SerializeField]
    protected string itemName;
    [SerializeField]
    protected TextAsset itemDescription;
    [SerializeField]
    protected Sprite itemImage;
    [SerializeField]
    protected Item_ID iD;
    [SerializeField]
    protected Item_Type type;
    [SerializeField]
    protected Player.Player_Inventory inventory;
    [SerializeField]
    protected Event_GetItem eventGetItem;
    [SerializeField]
    protected Event_UseItem eventUseItem;
    [SerializeField]
    protected Event_SelectItem eventSelectItem;

    public string ItemName { get { return itemName; } }
    public string ItemDescription { get { return itemDescription.text; } }
    public Sprite ItemImage { get { return itemImage; } }

    public abstract void GetNewItem();
    public abstract void UseItem();
}
