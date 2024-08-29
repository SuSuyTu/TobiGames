using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    IPlayerState currentState;
    public PlayerAttackingState playerAttackingState = new PlayerAttackingState();
    public PlayerIdlingState playerIdlingState = new PlayerIdlingState();
    public PlayerRunningState playerRunningState = new PlayerRunningState();
    
    protected virtual void Start()
    {
        currentState = playerIdlingState;
        currentState.OnEnter();
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        currentState.OnCollisionEnter(this, other);
    }
    protected virtual void Update() 
    {
        currentState.UpdateState(this);
    }

    public virtual void SwitchState(IPlayerState state)
    {
        currentState.OnExit();

        currentState = state;
        
        currentState.OnEnter();
    }

    public virtual void OnRespawn()
    {
        Debug.Log(currentState);
        currentState = playerIdlingState;
        currentState.OnEnter();
    }

    public virtual void OnDespawn()
    {
        transform.parent.position =  Vector3.zero;
        PlayerCtrl.Instance.PlayerAttackRange.EnemiesInRange.Clear();
        PlayerSpawner.Instance.Prefabs[0].gameObject.SetActive(false);
    }
}
