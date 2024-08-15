using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCollectingState : BotBaseState
{
    public override void EnterState(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool("isCollecting", true);
    }

    public override void ExitState(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool("isCollecting", false);
    }
    public override void UpdateState(BotStateManager state)
    {        
        if (!state.IsReachDestination()) return;
        SetTargetForEnemy(state);

        // Check to change state
        // if (t.Bricks.Count < t.maxBrickCanHold) t.ChangeState(t.FindBrickState);
        // else t.ChangeState(t.GoStairState);
    }

    public virtual void SetTargetForEnemy(BotStateManager state)
    {
        //if (state.hasTarget) return;
        // Get Brick Destination
        Vector2Int targetBrickCoordinate = state.BotCtrl.BotGameSession.CurrentGridManager.GetRandomPoint();
        if (targetBrickCoordinate == Vector2Int.zero || state.BotCtrl.BotGameSession.CurrentGridManager.Grid[targetBrickCoordinate].color != state.BotCtrl.Color) return;
    
        // if (brickWillFind == null) t.ChangeState(t.GoStairState);
        // if (brickWillFind.transform == null) t.ChangeState(t.IdleState);
        // Set Moving
        Vector3 position = new Vector3();
        position.x = targetBrickCoordinate.x;
        position.z = targetBrickCoordinate.y;
        state.destination = position;
        state.BotCtrl.NavMeshAgent.destination = state.destination;
        state.BotCtrl.transform.LookAt(state.destination);
        state.BotCtrl.NavMeshAgent.speed = Random.Range(3, 5);
    }

}
