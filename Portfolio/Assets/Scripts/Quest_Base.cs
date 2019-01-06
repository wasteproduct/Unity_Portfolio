﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "", order = 1)]
public class Quest_Base : ScriptableObject
{
    [SerializeField]
    private TextAsset questText;

    public TextAsset QuestText { get { return questText; } }
}
