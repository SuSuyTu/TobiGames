using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBotState 
{
    void OnEnter(BotStateManager state);
    void UpdateState(BotStateManager state);
    void OnCollisionEnter(BotStateManager state, Collision other);
    void OnTriggerEnter(BotStateManager state, Collider other);
    void OnExit(BotStateManager state);
}
