using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : IPlayerState
{
    private float despawnTimer = 0.5f;
    private float timer;
    private bool isDespawn;
    public void OnEnter()
    {
        UIManager.Instance.FloatingJoystick.gameObject.SetActive(false);
        GoldManager.Instance.GetGoldAfterStage(PlayerCtrl.Instance.point);
        PlayerCtrl.Instance.point = 0;
        PlayerCtrl.Instance.isDead = true;
        PlayerCtrl.Instance.Animator.SetBool(Constants.AnimType.DEAD, true);
    }

    public void UpdateState(PlayerStateManager state)
    {
        if (isDespawn)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= despawnTimer)
        {
            Despawn(state);
        }
    }

    protected virtual void Despawn(PlayerStateManager state)
    {
        GameManager.Instance.SwitchState(GameState.Lose);
        isDespawn = true;
        state.OnDespawn();
    }

    public void OnExit()
    {
        PlayerCtrl.Instance.Animator.SetBool(Constants.AnimType.DEAD, false);
    }

    public void OnCollisionEnter(PlayerStateManager state, Collision other)
    {
    }

    public void OnTriggerEnter(PlayerStateManager state, Collider other)
    {

    }
}
