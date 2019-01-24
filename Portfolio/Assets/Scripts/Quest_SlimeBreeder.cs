using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Quest/Slime Breeder", order = 1)]
public class Quest_SlimeBreeder : Quest_Base
{
    [SerializeField]
    private Item_SlimeGirl slimeGirl;

    public override void ProgressionCompleted()
    {
        slimeGirl.GetNewItem();
    }
}
