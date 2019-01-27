using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Quest/Strawberry Juice", order = 1)]
public class Quest_StrawberryJuice : Quest_Base
{
    [SerializeField]
    private Item_ID healingPotionID;

    public override bool ProgressionComplete()
    {
        for (int i = 0; i < inventory.Items.Count; i++)
        {
            if (inventory.Items[i].ItemID == healingPotionID) return true;
        }

        return false;
    }

    protected override void FinishQuest_Abstract()
    {
        inventory.RemoveItem_ByID(healingPotionID);
    }

    protected override void ProgressionCompleted() { }
}
