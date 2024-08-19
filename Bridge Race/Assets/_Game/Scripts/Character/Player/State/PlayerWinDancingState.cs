using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinDancingState : PlayerBaseState
{
    public override void EnterState()
    {
        PlayerCtrl.Instance.Animator.SetBool("isRunning", false);
        PlayerCtrl.Instance.Animator.SetBool("isIdling", false);
        PlayerCtrl.Instance.PlayerMovement.gameObject.SetActive(false);
        PlayerCtrl.Instance.PlayerMovement.FloatingJoystick.gameObject.SetActive(false);
        PlayerCtrl.Instance.Animator.SetTrigger("Win");
    }
}
