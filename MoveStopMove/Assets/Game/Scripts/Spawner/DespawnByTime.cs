using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : MonoBehaviour
{
    [SerializeField] protected float existTime;

    private float timer;

    protected virtual void FixedUpdate() 
    {
        timer += Time.fixedDeltaTime;
        if (timer < existTime) return;
        FXSpawner.Instance.Despawn(this.transform);    
    }

    protected virtual void OnEnable() 
    {
        timer = 0;    
    }
}
