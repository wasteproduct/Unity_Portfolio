using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBehaviour_TreasureBox : StateMachineBehaviour
{
    [SerializeField]
    private Event_Click eventClick;

    private bool opened = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        eventClick.interactorTile.Type = TileDataSet.TileType.Floor;
    }

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
