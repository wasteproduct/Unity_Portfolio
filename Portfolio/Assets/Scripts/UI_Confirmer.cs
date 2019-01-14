﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Confirmer : UI_Window_Base
{
    [SerializeField]
    private Text confirmedContents;

    public delegate void Delegate_Void();

    public Delegate_Void VoidMethod { get; private set; }

    public void SetVoidMethod(Delegate_Void method) { VoidMethod = method; }

    public void SetConfirmedContents(string text) { confirmedContents.text = text; }

    public void Yes_Void() { VoidMethod(); }

    public void No()
    {
        gameObject.SetActive(false);
    }

    protected override void CustomOnDisable()
    {
        VoidMethod = null;
    }
}
