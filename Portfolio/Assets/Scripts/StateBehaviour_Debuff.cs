using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle;

public class StateBehaviour_Debuff : StateMachineBehaviour
{
    public Character_State idleBattle;
    public Manager_BattlePhase phaseManager;
    public Battle_TargetManager targetManager;
    public Battle_ActionManager actionManager;

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetInteger("CurrentState", idleBattle.value);

        List<Character_InBattle> finalTargets = targetManager.FinalTargets;
        Battle_Action executedAction = actionManager.ExecutedAction;

        for (int i = 0; i < finalTargets.Count; i++)
        {
            finalTargets[i].ApplyDebuff(executedAction.DebuffInformation);
        }

        phaseManager.EnterNextPhase();
    }
}
