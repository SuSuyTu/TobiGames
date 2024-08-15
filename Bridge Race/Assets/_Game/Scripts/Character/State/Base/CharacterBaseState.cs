using Unity.VisualScripting;
using UnityEngine;

public abstract class CharacterBaseState 
{
    public abstract void EnterState();
    //public abstract void UpdateState(PlayerStateManager state);
    public abstract void UpdateState(CharacterStateManager state);
    public abstract void OnCollisionEnter(CharacterStateManager state, Collision other);
    public abstract void ExitState();
}
