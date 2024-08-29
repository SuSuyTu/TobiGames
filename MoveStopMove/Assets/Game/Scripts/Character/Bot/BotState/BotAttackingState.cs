using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAttackingState : IBotState
{
    private const float attackTime = Constants.CharacterAttack.ATTACK_TIME;
    private const float attackSpeed = Constants.CharacterAttack.ATTACK_SPEED;

    private float timer;
    private Vector3 targetPos;

    public void OnEnter(BotStateManager state)
    {
        timer = 0;
        //targetPos = e.GetRandomEnemyPos();

        targetPos = state.BotCtrl.CharacterAttackRange.EnemiesInRange[0].transform.position;
        state.BotCtrl.NavMeshAgent.ResetPath();
        state.BotCtrl.Animator.SetBool(Constants.AnimType.ATTACK, true);
    }

    public void UpdateState(BotStateManager state)
    {
        state.BotCtrl.RotateTo(targetPos);
        timer += Time.deltaTime;
 
        if (timer >= attackSpeed && state.BotCtrl.IsAttackable)
        {
            state.BotCtrl.CharacterAttackRange.Attack(targetPos);
        }
        else if (timer >= attackTime)
        {
            state.SwitchState(state.botIdlingState);
        }
    }

    public void OnExit(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool(Constants.AnimType.ATTACK, false);
    }

    public void OnCollisionEnter(BotStateManager state, Collision other)
    {

    }

    public void OnTriggerEnter(BotStateManager state, Collider other)
    {

    }
}
