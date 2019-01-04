using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBehaviour_TreasureBox : StateMachineBehaviour
{
    private bool opened = false;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (opened == true) return;

        if (animatorStateInfo.normalizedTime >= 1.0f)
        {
            opened = true;
            animator.gameObject.GetComponent<Interactor_BridgeScript>().CallReaction();
        }
    }
}
