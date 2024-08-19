using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCollectingState : BotBaseState
{
    protected int targetBricksNumber;
    public override void EnterState(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool("isCollecting", true);
        targetBricksNumber = Random.Range(12, 15);
    }

    public override void ExitState(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool("isCollecting", false);
    }
    public override void UpdateState(BotStateManager state)
    {        
        if (!state.IsReachDestination()) return;
        if (!SetTargetForEnemy(state)) state.SwitchState(state.botIdlingState);

        // Debug.Log(state.BotCtrl.BotBackpack.BotBrickStack.Count);
        // Debug.Log(state.BotCtrl.BotGameSession.CurrentBridgeManager.GetNumOfStep());
        if (state.BotCtrl.BotBackpack.BotBrickStack.Count >= targetBricksNumber)
            //state.BotCtrl.BotGameSession.CurrentBridgeManager.GetNumOfStep() && state.BotCtrl.BotGameSession.CurrentBridgeManager.GetNumOfStep() != 0) //- Random.Range(0, 5))
                state.SwitchState(state.botBuildingState);
    }
    public override void OnTriggerEnter(BotStateManager state, Collider other)
    {
        if (other.gameObject.CompareTag("Brick") 
            && other.gameObject.GetComponent<Brick>().Color.ToString() == state.BotCtrl.Color.ToString())
        {
            state.BotCtrl.BotBackpack.AddStack(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Fallen Brick"))
        {
            state.BotCtrl.BotBackpack.AddFallenStack(other.gameObject);
        }
    }

    public virtual bool SetTargetForEnemy(BotStateManager state)
    {
        Vector2Int targetBrickCoordinate = state.BotCtrl.BotGameSession.CurrentGridManager.GetRandomPoint();
        if (targetBrickCoordinate == Vector2Int.zero || state.BotCtrl.BotGameSession.CurrentGridManager.Grid[targetBrickCoordinate].color != state.BotCtrl.Color) return false;

        Vector3 position = new()
        {
            x = targetBrickCoordinate.x,
            y = state.BotCtrl.BotGameSession.CurrentGround.transform.position.y,
            z = targetBrickCoordinate.y
        };
        state.destination = position;
        state.BotCtrl.NavMeshAgent.destination = state.destination;
        state.BotCtrl.transform.LookAt(state.destination);
        //state.BotCtrl.NavMeshAgent.speed = Random.Range(10, 15);
        return true;
    }
}
