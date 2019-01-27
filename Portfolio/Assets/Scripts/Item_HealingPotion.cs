using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Item/Healing Potion", order = 1)]
public class Item_HealingPotion : Item_Base
{
    [SerializeField]
    private Quest_Base relevantQuest;

    public override void UseItem()
    {
        eventUseItem.TargetCharacter.CharacterCondition.Heal(50.0f);

        inventory.RemoveItem(eventSelectItem.SelectedItem);

        relevantQuest.UpdateProgression(false);
    }

    public override void GetNewItem()
    {
        Item_HealingPotion newPotion = CreateInstance<Item_HealingPotion>();
        newPotion.itemName = itemName;
        newPotion.itemDescription = itemDescription;
        newPotion.itemImage = itemImage;
        newPotion.iD = iD;
        newPotion.itemType = itemType;
        newPotion.inventory = inventory;
        newPotion.eventGetItem = eventGetItem;
        newPotion.eventUseItem = eventUseItem;
        newPotion.eventSelectItem = eventSelectItem;
        newPotion.relevantQuest = relevantQuest;

        inventory.AddNewItem(newPotion);

        relevantQuest.UpdateProgression();

        eventGetItem.NewItem = newPotion;
        eventGetItem.Run();
    }
}
