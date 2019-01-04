using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor_BridgeScript : MonoBehaviour
{
    [SerializeField]
    private Interactor_Base interactorScript;

    public void CallReaction()
    {
        interactorScript.CallReaction();
    }
}
