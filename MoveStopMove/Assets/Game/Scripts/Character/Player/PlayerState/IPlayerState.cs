using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState 
{
    void OnEnter();
    void UpdateState(PlayerStateManager state);
    void OnCollisionEnter(PlayerStateManager state, Collision other);
    void OnTriggerEnter(PlayerStateManager state, Collider other);
    void OnExit();
}
