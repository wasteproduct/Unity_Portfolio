using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBehaviour_Damage : StateMachineBehaviour
{
    public Character_State idleBattle;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetInteger("CurrentState", idleBattle.value);
    }
}
