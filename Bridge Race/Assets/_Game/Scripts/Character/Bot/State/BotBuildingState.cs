using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBuildingState : BotBaseState
{
    public override void EnterState(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool("isBuilding", true);
    }

    public override void ExitState(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool("isBuilding", false);
    }
    public override void UpdateState(BotStateManager state)
    {
        
    }

}
