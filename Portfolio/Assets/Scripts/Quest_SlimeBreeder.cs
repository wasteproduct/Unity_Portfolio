using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Quest/Slime Breeder", order = 1)]
public class Quest_SlimeBreeder : Quest_Base
{
    [SerializeField]
    private Item_SlimeGirl slimeGirl;

    public override bool ProgressionComplete() { return Progress >= 3; }

    protected override void FinishQuest_Abstract()
    {
        inventory.RemoveItem_ByID(slimeGirl.ItemID);
    }

    protected override void ProgressionCompleted()
    {
        slimeGirl.GetNewItem();
    }
}
