﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miscellaneous_UIRotation : MonoBehaviour
{
    public Variable_Quaternion rotationBattleUI;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotationBattleUI.value;
    }
}
