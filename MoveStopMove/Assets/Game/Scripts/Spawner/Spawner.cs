using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount { get => spawnedCount; }

    [Header("Object Pool")]
    [SerializeField] protected List<Transform> prefabs;
    public List<Transform> Prefabs => prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    protected virtual void Reset()
    {
        this.LoadPrefab();
        this.LoadHolder();
    }

    protected virtual void LoadHolder() {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefab()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj) {
            this.prefabs.Add(prefab);
        }

        this.HidePrefabs();

        Debug.LogWarning(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs) {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation) 
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        
        if (prefab == null) 
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }

        return this.Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation) 
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        //newPrefab.position = spawnPos;
        newPrefab.SetParent(this.holder);
        
        this.spawnedCount++;
        return newPrefab;
    }

    public virtual Transform SpawnInParent(string prefabName, Transform parent) 
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        
        if (prefab == null) 
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }

        return this.SpawnInParent(prefab, parent);
    }

    public virtual Transform SpawnInParent(Transform prefab, Transform parent) 
    {
        Transform newPrefab = this.GetObjectFromPool(prefab, parent);
        //newPrefab.SetPositionAndRotation(spawnPos, rotation);
        //newPrefab.position = spawnPos;
        newPrefab.SetParent(parent);
        
        this.spawnedCount++;
        return newPrefab;
    }

    public virtual Transform SpawnWithSpawnPos(string prefabName, Vector3 spawnPos) 
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        
        if (prefab == null) 
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }

        return this.SpawnWithSpawnPos(prefab, spawnPos);
    }

    public virtual Transform SpawnWithSpawnPos(Transform prefab, Vector3 spawnPos) 
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.position = spawnPos;
        //newPrefab.SetParent(this.holder);
        // newPrefab.position = spawnPos;
        
        this.spawnedCount++;
        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        foreach(Transform poolObj in this.poolObjs)
        {
            if (poolObj == null) continue;

            if (poolObj.name == prefab.name)  
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab, Transform parent)
    {
        foreach(Transform poolObj in this.poolObjs)
        {
            if (poolObj == null) continue;

            if (poolObj.name == prefab.name)  
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab, parent);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolObj in this.poolObjs)
        {
            if (poolObj == null) continue;

            if (poolObj.name == prefab.name)  
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj) 
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs) 
        {
            if (prefab.name == prefabName) {return prefab;}
        }
        return null;
    }

    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }

    public virtual void Hold(Transform obj)
    {
        obj.parent =  this.holder;
    }
}
