using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Event/Select Item", order = 1)]
public class Event_SelectItem : CustomEvent
{
    public Item_Base SelectedItem { get; set; }
}
