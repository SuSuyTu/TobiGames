using System;
using UnityEngine;
using UnityEngine.AI;

public class BotSpawner : Spawner
{
    [SerializeField] protected int limitX;
    [SerializeField] protected int limitZ;
    private static BotSpawner instance;
    public static BotSpawner Instance { get => instance; }
    protected virtual void Awake()
    {
        if (BotSpawner.instance != null) Debug.LogError("Only 1 BotSpawner allow to exist");
        BotSpawner.instance = this;
    }

    public float radius = 40f;

    public Vector3 GetRandomPositionOnNavMesh()
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
        //Debug.Log(randomDirection);
    
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
        {
            //Debug.Log(hit.position);
            return hit.position;
        }

        return transform.position;
    }
    private void OnDrawGizmos()
    {
        // Set the Gizmos color
        Gizmos.color = Color.red;

        // Draw the wire sphere at the GameObject's position
        Gizmos.DrawWireSphere(transform.position, radius);
    }   

    public virtual Transform SpawnRandomPos(String prefabName, Quaternion rotation)
    {
        // spawnPos = GetRandomBotSpawnPoint();
        // while (spawnPos == Vector3.zero) 
        // {
        //     spawnPos = GetRandomBotSpawnPoint();
        // }
        Vector3 pos = GetRandomPositionOnNavMesh();
        //Debug.Log(pos);
        return Spawn(prefabName, pos, rotation);
    }

    // public override void Despawn(Transform obj) 
    // {
    //     this.poolObjs.Add(obj);
    //     obj.gameObject.SetActive(false);
    //     this.spawnedCount--;
    // }
}
