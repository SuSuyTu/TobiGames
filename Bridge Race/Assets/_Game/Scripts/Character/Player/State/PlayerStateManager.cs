using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : CharacterStateManager
{
    PlayerBaseState currentState;
    public PlayerIdlingState playerIdleState = new PlayerIdlingState();
    public PlayerRunningState playerRunningState = new PlayerRunningState();
    public PlayerWinDancingState playerWinDancingState = new PlayerWinDancingState();
    protected override void Start()
    {
        currentState = playerIdleState;
        currentState.EnterState();
    }

    protected override void OnCollisionEnter(Collision other)
    {
        currentState.OnCollisionEnter(this, other);
    }
    protected override void Update() 
    {
        currentState.UpdateState(this);
    }

    public virtual void SwitchState(PlayerBaseState state)
    {
        currentState.ExitState();

        currentState = state;
        
        currentState.EnterState();
    }

    public override void SwitchState(CharacterBaseState state)
    {
        
    }
}
