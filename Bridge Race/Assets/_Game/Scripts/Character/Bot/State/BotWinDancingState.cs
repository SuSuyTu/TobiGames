using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotWinDancingState : BotBaseState
{
    public override void EnterState(BotStateManager state)
    {
        state.BotCtrl.Animator.SetTrigger("Win");   
    }
}
