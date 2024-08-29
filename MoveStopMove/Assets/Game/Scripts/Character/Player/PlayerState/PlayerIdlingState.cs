using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdlingState : IPlayerState
{
    public void OnEnter()
    {
        PlayerCtrl.Instance.Animator.SetBool(Constants.AnimType.IDLE, true);
    }

    public void UpdateState(PlayerStateManager state)
    {
        if (PlayerCtrl.Instance.PlayerMovement.CheckInput() && !PlayerCtrl.Instance.isDead)
        {
            state.SwitchState(state.playerRunningState);
        }
        //Debug.Log(PlayerCtrl.Instance.PlayerAttackRange.FoundCharacter);
        if (PlayerCtrl.Instance.PlayerAttackRange.FoundCharacter && PlayerCtrl.Instance.IsAttackable)
        {
            state.SwitchState(state.playerAttackingState);
        }

        // if (GameManager.Instance.IsState(GameState.Gameplay) == false)
        // {
        //     return;
        // }

        // if (player.IsMoving)
        // {
        //     player.ChangeState(new PRunState());
        // }
        // if (player.FoundCharacter && player.IsAttackable)
        // {
        //     player.ChangeState(new PAttackState());
        // }
    }

    public void OnExit()
    {
        PlayerCtrl.Instance.Animator.SetBool(Constants.AnimType.IDLE, false);
    }

    public void OnCollisionEnter(PlayerStateManager state, Collision other)
    {
    }

    public void OnTriggerEnter(PlayerStateManager state, Collider other)
    {

    }
}
