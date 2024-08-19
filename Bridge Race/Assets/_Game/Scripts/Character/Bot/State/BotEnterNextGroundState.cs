using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotEnterNextGroundState : BotBaseState
{
    public override void EnterState(BotStateManager state)
    {
        state.targetBridge = null;
        state.BotCtrl.NavMeshAgent.ResetPath();
        EnterNextGround(state);
        state.SwitchState(state.botCollectingState);
    }

    protected virtual void EnterNextGround(BotStateManager state)
    {
        state.BotCtrl.BotGameSession.CurrentColorManager.RemoveFromList(state.BotCtrl.Color);

        state.BotCtrl.BotGameSession.SetCurrentGround(state.BotCtrl.BotGameSession.GetNextGround());
        state.BotCtrl.BotGameSession.FindCurrentManager();

        state.BotCtrl.BotGameSession.CurrentColorManager.AddToList(state.BotCtrl.Color);
        state.BotCtrl.BotGameSession.CurrentBrickManager.IsStartOfTheStage();
    }
}
