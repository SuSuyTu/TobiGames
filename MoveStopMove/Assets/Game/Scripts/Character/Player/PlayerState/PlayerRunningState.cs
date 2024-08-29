using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : IPlayerState
{
    public void OnCollisionEnter(PlayerStateManager state, Collision other)
    {
       
    }

    public void OnEnter()
    {
        PlayerCtrl.Instance.Animator.SetBool(Constants.AnimType.RUN, true);
    }

    public void UpdateState(PlayerStateManager state)
    {
        if (!PlayerCtrl.Instance.PlayerMovement.CheckInput())
        {
            state.SwitchState(state.playerIdlingState);
        }
    }

    public void OnExit()
    {
        PlayerCtrl.Instance.Animator.SetBool(Constants.AnimType.RUN, false);
    }

    public void OnTriggerEnter(PlayerStateManager state, Collider other)
    {
    
    }
}
