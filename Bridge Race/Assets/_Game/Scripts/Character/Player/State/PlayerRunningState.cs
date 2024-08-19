using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public override void EnterState()
    {
        PlayerCtrl.Instance.Animator.SetBool("isRunning", true);
    }

    public override void ExitState()
    {
        PlayerCtrl.Instance.Animator.SetBool("isRunning", false);
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
        if (PlayerCtrl.Instance.PlayerMovement.FloatingJoystick.Horizontal == 0 || PlayerCtrl.Instance.PlayerMovement.FloatingJoystick.Vertical == 0)
        {
            state.SwitchState(state.playerIdleState);
        }
    }

}
