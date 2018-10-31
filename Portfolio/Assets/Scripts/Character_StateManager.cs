using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_StateManager : MonoBehaviour
{
    public Character_StateList stateList;

    private Animator animator;

    public Character_State CurrentState { get; private set; }

    public void SetState(Character_State newState)
    {
        if (animator == null) return;
        
        CurrentState = newState;

        animator.SetInteger("CurrentState", CurrentState.value);
    }

    public void Initialize()
    {
        animator = GetComponentInChildren<Animator>(false);

        if (animator == null) return;

        CurrentState = stateList.idleExploration;

        animator.SetInteger("CurrentState", CurrentState.value);
    }
}
