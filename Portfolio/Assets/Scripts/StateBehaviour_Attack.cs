using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle;

public class StateBehaviour_Attack : StateMachineBehaviour
{
    public Character_State idleBattle;
    public Manager_BattlePhase phaseManager;
    public Battle_TargetManager targetManager;
    public Battle_TurnController turnController;
    public float targetHitTime;

    private bool targetHit;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        targetHit = false;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetInteger("CurrentState", idleBattle.value);
        phaseManager.EnterNextPhase();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (targetHit == true) return;

        if (animatorStateInfo.normalizedTime >= targetHitTime)
        {
            targetHit = true;
            // play hit motion
            Character_InBattle hitTarget = targetManager.Target.GetComponent<Character_InBattle>();
            hitTarget.Damage(turnController.CurrentTurnCharacter.actionAttack.Power);
        }
    }
}
