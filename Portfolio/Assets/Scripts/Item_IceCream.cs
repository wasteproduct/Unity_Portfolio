using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Item/Ice Cream", order = 1)]
public class Item_IceCream : Item_Base
{
    public override void UseItem() { }

    public override void GetNewItem()
    {
        Item_IceCream iceCream = CreateInstance<Item_IceCream>();

        iceCream.itemName = itemName;
        iceCream.itemDescription = itemDescription;
        iceCream.itemImage = itemImage;
        iceCream.iD = iD;
        iceCream.itemType = itemType;
        iceCream.inventory = inventory;
        iceCream.eventGetItem = eventGetItem;
        iceCream.eventUseItem = eventUseItem;
        iceCream.eventSelectItem = eventSelectItem;

        inventory.AddNewItem(iceCream);

        eventGetItem.NewItem = iceCream;
        eventGetItem.Run();
    }
}
