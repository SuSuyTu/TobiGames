using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerAttackingState : IPlayerState
{
    private float attackTime = Constants.CharacterAttack.ATTACK_TIME;
    private float attackSpeed = Constants.CharacterAttack.ATTACK_SPEED;

    private float timer;
    private Vector3 targetPos;

    public void OnEnter()
    {
        PlayerCtrl.Instance.Animator.SetBool(Constants.AnimType.ATTACK, true);
        timer = 0;
        PlayerCtrl.Instance.IsAttacking = true;

        
        targetPos = PlayerCtrl.Instance.PlayerAttackRange.EnemiesInRange[0].transform.position;
    }

    public void UpdateState(PlayerStateManager state)
    {
        PlayerCtrl.Instance.PlayerMovement.RotateTo(targetPos);
        
        if (!PlayerCtrl.Instance.PlayerMovement.CheckInput() && !PlayerCtrl.Instance.IsAttackable)
        {
            state.SwitchState(state.playerIdlingState);
        }

        timer += Time.deltaTime;

        if (timer >= attackSpeed && PlayerCtrl.Instance.IsAttackable)
        {
            PlayerCtrl.Instance.PlayerAttackRange.Attack(targetPos);
        }
        else if (timer >= attackTime)
        {
            state.SwitchState(state.playerIdlingState);
        }
    }

    public void OnExit()
    {
        PlayerCtrl.Instance.IsAttacking = false;
        PlayerCtrl.Instance.Animator.SetBool(Constants.AnimType.ATTACK, false);
    }

    public void OnCollisionEnter(PlayerStateManager state, Collision other)
    {

    }

    public void OnTriggerEnter(PlayerStateManager state, Collider other)
    {

    }

}
