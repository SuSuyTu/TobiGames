using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBaseState : CharacterBaseState
{
    public override void EnterState()
    {
        
    }

    public override void ExitState()
    {
     
    }

    public override void OnCollisionEnter(CharacterStateManager state, Collision other)
    {
      
    }

    public override void UpdateState(CharacterStateManager state)
    {
        
    }
    public virtual void EnterState(BotStateManager state)
    {
        
    }
    public virtual void ExitState(BotStateManager state)
    {
     
    }
    public virtual void UpdateState(BotStateManager state)
    {
        
    }
}
