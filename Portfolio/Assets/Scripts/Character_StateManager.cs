using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_StateManager : MonoBehaviour
{
    public Character_StateList stateList;

    private Animator animator;

    public Character_State CurrentState { get; private set; }

    public void SetState_Idle(bool battlePhase)
    {
        if (animator == null) return;

        CurrentState = (battlePhase == true) ? stateList.idleBattle : stateList.idleExploration;

        animator.SetInteger("CurrentState", CurrentState.value);
    }

    public void SetState_Run(bool battlePhase)
    {
        if (animator == null) return;

        CurrentState = (battlePhase == true) ? stateList.runBattle : stateList.runExploration;

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
