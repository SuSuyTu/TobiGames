using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotBuildingState : BotBaseState
{
    //protected Bridge currentBridge;
    public override void EnterState(BotStateManager state)
    {
        state.BotCtrl.NavMeshAgent.ResetPath();
        if (SetTargetBridge(state))
        {
            state.BotCtrl.Animator.SetBool("isBuilding", true);
        }

        else
        {
            state.SwitchState(state.botIdlingState);
        }
        
        
    }

    public override void ExitState(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool("isBuilding", false);
    }

    public override void OnTriggerEnter(BotStateManager state, Collider other)
    {
        if (other.gameObject.CompareTag("NextStage"))
        {
            state.targetBridge.SetIsFinished(true);
            state.SwitchState(state.botEnterNextGroundState);
            other.gameObject.SetActive(false);
        }
    }
    public override void UpdateState(BotStateManager state)
    {
        if (state.targetBridge.IsFinished) state.SwitchState(state.botCollectingState);
        //if (!state.IsReachDestination()) return;
        // if (state.IsReachDestination()) return;
        BuildBridge(state);
    }

    protected virtual bool SetTargetBridge(BotStateManager state)
    {
        if (state.BotCtrl.BotGameSession.CurrentBridgeManager.GetRadomBridge() == null) return false;
        state.targetBridge = state.BotCtrl.BotGameSession.CurrentBridgeManager.GetRadomBridge();
        state.SetDestination(state.targetBridge.StartPoint.position);
        if (state.targetBridge.IsFinished) return false;
        return true;
    }

    protected virtual void BuildBridge(BotStateManager state)
    {
        for (int i = 0; i < state.targetBridge.Steps.Count; i++)
        {
            if (state.targetBridge.IsFinished) 
            {
                state.BotCtrl.NavMeshAgent.ResetPath();
                state.SwitchState(state.botCollectingState);
                return;
            }
            else 
            {
                if (!state.IsReachDestination()) return;
                state.SetDestination(state.targetBridge.Steps[i].position);
            }
        
            if (state.BotCtrl.BotBackpack.BotBrickStack.Count == 0 && !state.targetBridge.IsFinished)
            {
                state.BotCtrl.NavMeshAgent.ResetPath();
                state.SwitchState(state.botCollectingState);
                return;
            }
        }
        state.SetDestination(state.targetBridge.NextStagePoint.position);
    }

}
