using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_StateManager : MonoBehaviour
{
    public Character_State idle;
    public Character_State run;

    private Animator animator;

    public Character_State CurrentState { get; private set; }

    public void SetState_Idle()
    {
        CurrentState = idle;
        animator.SetInteger("CurrentState", CurrentState.value);
    }

    public void SetState_Run()
    {
        CurrentState = run;
        animator.SetInteger("CurrentState", CurrentState.value);
    }

    public void Initialize()
    {
        animator = GetComponentInChildren<Animator>(false);

        CurrentState = idle;
        animator.SetInteger("CurrentState", CurrentState.value);
    }
}
