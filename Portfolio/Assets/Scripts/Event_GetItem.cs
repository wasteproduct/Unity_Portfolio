﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Event/Get Item", order = 1)]
public class Event_GetItem : CustomEvent
{
    public Item_Base NewItem { get; set; }
}
