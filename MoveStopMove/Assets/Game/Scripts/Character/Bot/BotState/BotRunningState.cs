using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotRunningState : IBotState
{
    private Vector3 nextDestination;
    // private bool attackIfEnemyInRange;
    public void OnEnter(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool(Constants.AnimType.RUN, true);
        nextDestination = BotSpawner.Instance.GetRandomPositionOnNavMesh();
        state.BotCtrl.MoveTo(nextDestination);
    }
 
     public void UpdateState(BotStateManager state)
    {
        if (state.BotCtrl.CharacterAttackRange.FoundCharacter && state.BotCtrl.IsAttackable)
        {
            state.SwitchState(state.botAttackingState);
        }
        if (state.IsReachDestination())
        {
            state.SwitchState(state.botIdlingState);
        }
    }

    public void OnExit(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool(Constants.AnimType.RUN, false);
    }
    
    public void OnCollisionEnter(BotStateManager state, Collision other)
    {
        
    }

    public void OnTriggerEnter(BotStateManager state, Collider other)
    {
       
    }
}
