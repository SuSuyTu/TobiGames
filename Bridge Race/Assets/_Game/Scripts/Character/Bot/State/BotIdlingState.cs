using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotIdlingState : BotBaseState
{
    public bool isIdlingIfinity;
    public override void EnterState(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool("isIdling", true);
    }

    public override void ExitState(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool("isIdling", false);
    }
    public override void UpdateState(BotStateManager state)
    {
        if (isIdlingIfinity) return;
        else if (state.botCollectingState.SetTargetForEnemy(state))
        {
            state.SwitchState(state.botCollectingState);
        }
    }
}
