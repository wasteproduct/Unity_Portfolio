﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character_Explore : MonoBehaviour
{
    public Vector3 PreviousPosition { get; protected set; }
    public GameObject FrontOne { get; protected set; }

    public abstract void Initialize(GameObject frontOne);
    public abstract void StartMoving();
}
