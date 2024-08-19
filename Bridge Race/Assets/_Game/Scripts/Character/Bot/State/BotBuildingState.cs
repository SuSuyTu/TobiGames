using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotBuildingState : BotBaseState
{
    public override void EnterState(BotStateManager state)
    {
        if (SetTargetBridge(state))
        {
            state.SetDestination(state.targetBridge.StartPoint.position);
            state.BotCtrl.Animator.SetBool("isBuilding", true);
            BuildBridge(state);
        }

        else
        {
            state.botIdlingState.isIdlingIfinity = true;
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
        if (state.targetBridge == null) return;
        if (state.targetBridge.IsFinished)
        {
            state.BotCtrl.NavMeshAgent.ResetPath();
            state.SwitchState(state.botCollectingState);
        } 

        if (state.BotCtrl.BotBackpack.BotBrickStack.Count == 0 && !state.targetBridge.IsFinished)
        {
            state.BotCtrl.NavMeshAgent.ResetPath();
            state.SwitchState(state.botCollectingState);
        }
    }

    protected virtual bool SetTargetBridge(BotStateManager state)
    {
        if (state.BotCtrl.BotGameSession.CurrentBridgeManager.Bridges == null) return false;
        state.targetBridge = state.BotCtrl.BotGameSession.CurrentBridgeManager.GetRadomBridge();
        if (state.targetBridge.IsFinished) return false;
        return true;
    }

    protected virtual void BuildBridge(BotStateManager state)
    {
        // for (int i = 0; i < state.targetBridge.Steps.Count; i++)
        // {
        //     if (i != state.targetBridge.Steps.Count - 1)
        //     {
        //         state.SetDestination(state.targetBridge.Steps[i].position);
        //     }
        //     else if (state.BotCtrl.BotBackpack.BotBrickStack.Count > 0 && i == state.targetBridge.Steps.Count - 1)
        //     {
        //         state.SetDestination(state.targetBridge.Steps[i].position);
        //     }
        //     else
        //     {
        //         state.BotCtrl.NavMeshAgent.ResetPath();
        //         state.SwitchState(state.botCollectingState);
        //     }
        //     // if (state.BotCtrl.BotBackpack.BotBrickStack.Count == 0 && !state.targetBridge.IsFinished && i != state.targetBridge.Steps.Count - 1)
        //     // {
        //     //     // if (!state.IsReachDestination()) return;
        //     //     state.SwitchState(state.botCollectingState);
        //     //     //state.SwitchState(state.botIdlingState);
        //     // }
        //     // state.SetDestination(state.targetBridge.Steps[i].position);
        // } 
        state.SetDestination(state.targetBridge.NextStagePoint.position);
    }

}
