using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityObjectControler : ShootAbleObjectControler
{
    [Header("Ability Object")]
    [SerializeField] protected SpawnPoint spawnPoint;
    public SpawnPoint _spawnPoint => spawnPoint;

     protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if(this.spawnPoint != null) return;
        this.spawnPoint = GetComponentInChildren<SpawnPoint>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }
}
