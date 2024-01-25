using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public abstract class Spawner : NewMonobehavior
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected int spawnerCount = 0;
    public int SpawnerCount => spawnerCount;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHodler();
    }

    protected virtual void LoadHodler()
    {
        if(this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if(this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();

        Debug.LogWarning(transform.name + "; LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(String prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab == null)
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

        newPrefab.parent = this.holder;
        this.spawnerCount++;
        return newPrefab;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {   
                if(poolObj.name == prefab.name)
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
        this.spawnerCount--;
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            if(prefab.name == prefabName) return prefab;
        }

        return null;
    }
    
    public virtual Transform RandomPrefab()
    {
        int rand = UnityEngine.Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }

    public virtual void Holder(Transform obj)
    {
        obj.parent = this.holder;
    }
}
