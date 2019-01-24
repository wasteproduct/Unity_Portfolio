using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Item/Healing Potion", order = 1)]
public class Item_HealingPotion : Item_Base
{
    public override void UseItem()
    {
        eventUseItem.TargetCharacter.CharacterCondition.Heal(50.0f);

        inventory.RemoveItem(eventSelectItem.SelectedItem);
    }

    public override void GetNewItem()
    {
        Item_HealingPotion newPotion = CreateInstance<Item_HealingPotion>();
        newPotion.itemName = itemName;
        newPotion.itemDescription = itemDescription;
        newPotion.itemImage = itemImage;
        newPotion.iD = iD;
        newPotion.inventory = inventory;
        newPotion.eventGetItem = eventGetItem;
        newPotion.eventUseItem = eventUseItem;
        newPotion.eventSelectItem = eventSelectItem;

        inventory.AddNewItem(newPotion);

        eventGetItem.NewItem = newPotion;
        eventGetItem.Run();
    }
}
