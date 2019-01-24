using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Item/Slime Girl", order = 1)]
public class Item_SlimeGirl : Item_Base
{
    public override void UseItem() { }

    public override void GetNewItem()
    {
        Item_SlimeGirl slimeGirl = CreateInstance<Item_SlimeGirl>();

        slimeGirl.itemName = itemName;
        slimeGirl.itemDescription = itemDescription;
        slimeGirl.itemImage = itemImage;
        slimeGirl.iD = iD;
        slimeGirl.itemType = itemType;
        slimeGirl.inventory = inventory;
        slimeGirl.eventGetItem = eventGetItem;
        slimeGirl.eventUseItem = eventUseItem;
        slimeGirl.eventSelectItem = eventSelectItem;

        inventory.AddNewItem(slimeGirl);

        eventGetItem.NewItem = slimeGirl;
        eventGetItem.Run();
    }
}
