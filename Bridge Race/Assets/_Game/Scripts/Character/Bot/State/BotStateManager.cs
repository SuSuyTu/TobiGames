using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotStateManager : CharacterStateManager
{
    [SerializeField] protected BotCtrl botCtrl;
    public BotCtrl BotCtrl => botCtrl;
    BotBaseState currentState;
    //public bool hasTarget = false;
    public Vector3 destination;
    public BotIdlingState botIdlingState = new BotIdlingState();
    public BotCollectingState botCollectingState = new BotCollectingState();
    public BotBuildingState botBuildingState = new BotBuildingState();
    protected override void Start()
    {
        currentState = botIdlingState;
        currentState.EnterState(this);
    }

    protected override void OnCollisionEnter(Collision other)
    {
        currentState.OnCollisionEnter(this, other);
    }
    protected override void Update() 
    {
        currentState.UpdateState(this);
    }

    public virtual void SwitchState(BotBaseState state)
    {
        currentState.ExitState(this);

        currentState = state;
        
        currentState.EnterState(this);
    }

    public virtual bool IsReachDestination()
    {   
        if (!(botCtrl.NavMeshAgent.remainingDistance <= botCtrl.NavMeshAgent.stoppingDistance)) return false;
        return !botCtrl.NavMeshAgent.hasPath || botCtrl.NavMeshAgent.velocity.sqrMagnitude == 0f;
    }

    public override void SwitchState(CharacterBaseState state)
    {
        
    }
}
