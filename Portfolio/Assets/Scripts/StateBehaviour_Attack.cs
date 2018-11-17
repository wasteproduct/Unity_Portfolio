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
    public Battle_ActionManager actionManager;
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

            List<Character_InBattle> finalTargets = targetManager.FinalTargets;
            Battle_Action executedAction = actionManager.ExecutedAction;

            finalTargets[0].Damage(executedAction.Power);
            for (int i = 1; i < finalTargets.Count; i++)
            {
                float splashedDamage = executedAction.Power * executedAction.SplashedPowerRate;
                finalTargets[i].Damage(splashedDamage);
            }
        }
    }
}
