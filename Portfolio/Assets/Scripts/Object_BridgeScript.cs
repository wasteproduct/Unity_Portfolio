using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_BridgeScript : MonoBehaviour
{
    [SerializeField]
    private Object_InteractorBase interactorScript;

    public void CallReaction()
    {
        interactorScript.CallReaction();
    }
}
