using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : MonoBehaviour
{
    [SerializeField] protected Spawner spawner;    
    public Spawner Spawner => spawner; 
    // [SerializeField] protected SpawnPoints spawnPoints;
    // public SpawnPoints SpawnPoints => spawnPoints; 
    protected virtual void Reset()
    {
        this.LoadSpawner();
        

    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    
}
