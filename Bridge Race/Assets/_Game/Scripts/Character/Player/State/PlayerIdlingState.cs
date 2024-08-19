using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdlingState : PlayerBaseState
{
    public override void EnterState()
    {
        PlayerCtrl.Instance.Animator.SetBool("isIdling", true);
    }

    public override void ExitState()
    {
        PlayerCtrl.Instance.Animator.SetBool("isIdling", false);
    }
    public override void OnTriggerEnter(PlayerStateManager state, Collider other) 
    {
        if (other.CompareTag("Finish"))
        {
            state.SwitchState(state.playerWinDancingState);
        }
    }

    public override void UpdateState(PlayerStateManager state)
    {
        if (PlayerCtrl.Instance.PlayerMovement.FloatingJoystick.Horizontal != 0 || PlayerCtrl.Instance.PlayerMovement.FloatingJoystick.Vertical != 0)
        {
            state.SwitchState(state.playerRunningState);
        }
    }

}
