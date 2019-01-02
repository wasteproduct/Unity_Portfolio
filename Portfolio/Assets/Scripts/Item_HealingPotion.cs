using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

[CreateAssetMenu(fileName = "", menuName = "Item/Healing Potion", order = 1)]
public class Item_HealingPotion : Item_Base
{
    public override void UseItem()
    {

    }

    public override void GetNewItem()
    {
        Item_HealingPotion newPotion = CreateInstance<Item_HealingPotion>();
        newPotion.itemImage = itemImage;
        newPotion.iD = iD;
        newPotion.inventory = inventory;

        inventory.AddNewItem(newPotion);
    }
}
