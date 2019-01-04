using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Interactor/Get Item", order = 1)]
public class Interactor_ReactionGetItem : Interactor_ReactionBase
{
    [SerializeField]
    private Item_Database itemDatabase;

    public override void InteractorReacts(Interactor_Base interactor)
    {
        Item_Base[] items = itemDatabase.Items;

        int itemNumber = Random.Range(0, items.Length);

        for (int i = 0; i < items.Length; i++)
        {
            if (i == itemNumber)
            {
                items[i].GetNewItem();
                break;
            }
        }

        Destroy(interactor.gameObject);
    }
}
