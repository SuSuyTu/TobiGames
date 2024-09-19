using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotDeadState : IBotState
{
    private float despawnTimer = Constants.SpawnAndDespawnTime.Bot_Despawn_Time;
    private float timer;
    private bool isDespawn;
    public void OnEnter(BotStateManager state)
    {
        IndicatorSpawner.Instance.Despawn(state.BotCtrl.botIndicator.transform.parent);
        Debug.Log(state.BotCtrl.characterName);
        state.BotCtrl.NavMeshAgent.ResetPath();
        timer = 0;
        isDespawn = false;
        state.BotCtrl.Animator.SetBool(Constants.AnimType.DEAD, true);
        state.BotCtrl.isDead = true;
    }

    public void UpdateState(BotStateManager state)
    {
        if (isDespawn)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= despawnTimer)
        { 
            timer = 0;
            //state.BotCtrl.CharacterSkin.TakeOffClothes();
            OnExit(state);
            //state.SwitchState(state.botIdlingState);
            //state.BotCtrl.transform.position = Vector3.zero;
            // state.BotCtrl.NavMeshAgent.enabled = true;
            GameManager.Instance.botCount -= 1;
            //BotSpawner.Instance.Despawn(state.BotCtrl.transform);
            state.BotCtrl.BotSpawner.Despawn(state.BotCtrl.transform);
            
        }
    }

    public void OnExit(BotStateManager state)
    {
        isDespawn = true;
        //state.BotCtrl.isDead = false;
        state.BotCtrl.Animator.SetBool(Constants.AnimType.DEAD, false);
    }

    public void OnCollisionEnter(BotStateManager state, Collision other)
    {
    }

    public void OnTriggerEnter(BotStateManager state, Collider other)
    {

    }
}
