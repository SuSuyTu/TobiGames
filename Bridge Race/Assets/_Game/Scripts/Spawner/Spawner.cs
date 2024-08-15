using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : NewMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
    // [SerializeField] protected int spawnedCount = 0;
    // public int SpawnedCount { get => spawnedCount; }

    [Header("Object Pool")]
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    protected override void LoadComponents()
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
        newPrefab.SetParent(this.holder);
        
        //this.spawnedCount++;
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
        obj.SetParent(this.holder);
        obj.gameObject.SetActive(false);
        //this.spawnedCount--;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs) 
        {
            if (prefab.name == prefabName) {return prefab;}
        }
        return null;
    }

    public virtual Transform GetPrefabByIndex(int index)
    {
        return prefabs[index];
    }

    public virtual void Hold(Transform obj)
    {
        obj.parent =  this.holder;
    }
}
