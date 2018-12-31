using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Base : ScriptableObject
{
    [SerializeField]
    protected Sprite itemImage;
    [SerializeField]
    protected Item_ID iD;
    [SerializeField]
    protected Player.Player_Inventory inventory;

    public Sprite ItemImage { get { return itemImage; } }

    public abstract void GetNewItem();
}
