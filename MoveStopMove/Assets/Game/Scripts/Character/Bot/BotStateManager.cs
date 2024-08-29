using UnityEngine;

public class BotStateManager : MonoBehaviour
{
    [SerializeField] protected BotCtrl botCtrl;
    public BotCtrl BotCtrl => botCtrl;
    IBotState currentState;
    public BotAttackingState botAttackingState = new BotAttackingState();
    public BotIdlingState botIdlingState = new BotIdlingState();
    public BotRunningState botRunningState = new BotRunningState();
    public BotDeadState botDeadState = new BotDeadState();
    protected virtual void OnEnable()
    {
        //idleTime = Random.Range(minIdleTime, maxIdleTime);
        currentState = botIdlingState;
        currentState.OnEnter(this);
    }

    // public virtual void Respawn()
    // {
    //     currentState = botIdlingState;
    //     currentState.OnEnter(this);
    //     botCtrl.NavMeshAgent.enabled = true;
    // }

    protected virtual void OnCollisionEnter(Collision other)
    {
        currentState.OnCollisionEnter(this, other);
    }
    protected virtual void Update() 
    {
        currentState.UpdateState(this);
    }

    public virtual void SwitchState(IBotState state)
    {
        if (state != null) 
        {
            currentState.OnExit(this);
        }
        

        currentState = state;
        
        currentState.OnEnter(this);
    }

    public virtual bool IsReachDestination()
    {   
        if (!(botCtrl.NavMeshAgent.remainingDistance <= botCtrl.NavMeshAgent.stoppingDistance)) return false;
        return !botCtrl.NavMeshAgent.hasPath || botCtrl.NavMeshAgent.velocity.sqrMagnitude == 0f;
    }
}
