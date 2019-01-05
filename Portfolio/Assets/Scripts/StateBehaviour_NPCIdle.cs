using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBehaviour_NPCIdle : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetInteger("CurrentState", 0);
    }
}
