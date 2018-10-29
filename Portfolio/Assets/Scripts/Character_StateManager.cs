using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_StateManager : MonoBehaviour
{
    public Character_State idleExploration;
    public Character_State runExploration;
    public Character_State idleBattle;
    public Character_State runBattle;

    private Animator animator;

    public Character_State CurrentState { get; private set; }

    public void SetState_Idle(bool battlePhase)
    {
        if (animator == null) return;

        CurrentState = (battlePhase == true) ? idleBattle : idleExploration;

        animator.SetInteger("CurrentState", CurrentState.value);
    }

    public void SetState_Run(bool battlePhase)
    {
        if (animator == null) return;

        CurrentState = (battlePhase == true) ? runBattle : runExploration;

        animator.SetInteger("CurrentState", CurrentState.value);
    }

    public void Initialize()
    {
        animator = GetComponentInChildren<Animator>(false);

        if (animator == null) return;

        CurrentState = idleExploration;

        animator.SetInteger("CurrentState", CurrentState.value);
    }
}
