using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle;

public class StateBehaviour_Attack : StateMachineBehaviour
{
    public Character_State idleBattle;
    public Manager_BattlePhase phaseManager;
    public Battle_TurnController turnController;
    public Battle_ActionManager actionManager;
    public Event_SoundPlay eventSoundPlay;
    public Battle_ImpactBase onImpact;
    public float impactTimePercentage;

    private bool impactOn;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        impactOn = false;

        // "maybe" temporary
        turnController.CurrentTurnCharacter.EffectManager.PlayActionEffect(actionManager.ExecutedAction);

        if (actionManager.ExecutedAction.ActionSound == null) return;

        eventSoundPlay.PlayedSound = actionManager.ExecutedAction.ActionSound;
        eventSoundPlay.Run();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetInteger("CurrentState", idleBattle.value);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (impactOn == true) return;

        if (animatorStateInfo.normalizedTime >= impactTimePercentage)
        {
            impactOn = true;

            onImpact.Run();
        }
    }
}
