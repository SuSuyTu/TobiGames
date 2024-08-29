using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotIdlingState : IBotState
{
    protected float idleTime;
    //protected int chanceAttack;
    protected float timer = 0;
    public void OnEnter(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool(Constants.AnimType.IDLE, true);
        //chanceAttack = Random.Range((int) Constants.StateTimerAndRate.attackMinChance, (int) Constants.StateTimerAndRate.attackMaxChance);
        idleTime = Random.Range((int) Constants.StateTimerAndRate.minIdleTime,(int) Constants.StateTimerAndRate.maxIdleTime);
        //state.BotCtrl.StopMove();
        timer = 0;
    }
 
    public void UpdateState(BotStateManager state)
    {
        timer += Time.fixedDeltaTime;
        if (timer >= idleTime)
        {
            state.SwitchState(state.botRunningState);
        }

        if (state.BotCtrl.CharacterAttackRange.FoundCharacter && state.BotCtrl.IsAttackable) //&& chanceAttack > 50)
        {
            state.SwitchState(state.botAttackingState);
        }
    }

    public void OnExit(BotStateManager state)
    {
        state.BotCtrl.Animator.SetBool(Constants.AnimType.IDLE, false);
    }

    public void OnCollisionEnter(BotStateManager state, Collision other)
    {

    }

    public void OnTriggerEnter(BotStateManager state, Collider other)
    {

    }
}
