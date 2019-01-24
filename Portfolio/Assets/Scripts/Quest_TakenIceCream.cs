using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Quest/Taken Ice Cream", order = 1)]
public class Quest_TakenIceCream : Quest_Base
{
    [SerializeField]
    private Item_IceCream iceCream;

    public override void ProgressionCompleted()
    {
        iceCream.GetNewItem();
    }
}
