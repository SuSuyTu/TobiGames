using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CharacterStateManager : NewMonoBehaviour
{
    protected abstract void OnCollisionEnter(Collision other);
    protected abstract void Update();
    public abstract void SwitchState(CharacterBaseState state);
}
