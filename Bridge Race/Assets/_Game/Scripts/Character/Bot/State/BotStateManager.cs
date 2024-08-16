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
    public Bridge targetBridge;
    public BotIdlingState botIdlingState = new BotIdlingState();
    public BotCollectingState botCollectingState = new BotCollectingState();
    public BotBuildingState botBuildingState = new BotBuildingState();
    public BotEnterNextGroundState botEnterNextGroundState = new BotEnterNextGroundState();

    public bool hasTargetBrick;
    protected override void Start()
    {
        currentState = botIdlingState;
        currentState.EnterState(this);
    }

    protected override void OnCollisionEnter(Collision other)
    {
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hello");
        currentState.OnTriggerEnter(this, other);
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
    public virtual void SetDestination(Vector3 position)
    {
        this.destination = position;
        this.BotCtrl.NavMeshAgent.destination = this.destination;
        this.BotCtrl.transform.LookAt(this.destination);
        this.BotCtrl.NavMeshAgent.speed = Random.Range(3, 5);
    }
}

