using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBehaviour_NPC_Greeting : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetInteger("CurrentState", 0);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (animatorStateInfo.normalizedTime >= 1.0f) animator.SetInteger("CurrentState", 0);
    }
}
