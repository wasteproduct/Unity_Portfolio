using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Item/Database", order = 1)]
public class Item_Database : ScriptableObject
{
    [SerializeField]
    private Item_Base[] items;

    public Item_Base[] Items { get { return items; } }
}
