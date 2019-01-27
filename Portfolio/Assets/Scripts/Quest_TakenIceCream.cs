using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Quest/Taken Ice Cream", order = 1)]
public class Quest_TakenIceCream : Quest_Base
{
    [SerializeField]
    private Item_IceCream iceCream;

    public override bool ProgressionComplete() { return Progress >= 1; }

    protected override void FinishQuest_Abstract()
    {
        inventory.RemoveItem_ByID(iceCream.ItemID);
    }

    protected override void ProgressionCompleted()
    {
        iceCream.GetNewItem();
    }
}
