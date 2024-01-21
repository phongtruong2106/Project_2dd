using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : NewMonobehavior
{
    [Header("Spawner Random")]
    [SerializeField] protected SpawnerControler spawnerControler;
    [SerializeField] protected float randomTimer = 1f;
    [SerializeField] protected float randomDelay = 0f;
    [SerializeField] protected float randomLimit = 9f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadControler();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.randomDelay = 1f;
        this.randomTimer = 0f;
        this.randomLimit = 9f;
    }

    protected virtual void LoadControler()
    {
        if(this.spawnerControler != null) return;
        this.spawnerControler = GetComponent<SpawnerControler>();
        Debug.Log(transform.name + ": LoadJunkControler", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if(this.RandomReachLimit()) return;
        this.randomTimer += Time.fixedDeltaTime;
        if(this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform ranPoint = this.spawnerControler.SpawnPoint.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion ros = transform.rotation;

        Transform prefab = this.spawnerControler._spawner.RandomPrefab();
        Transform obj =  this.spawnerControler._spawner.Spawn(prefab, pos, ros);
        obj.gameObject.SetActive(true);
        // Invoke(nameof(this.JunkSpawning), 1f);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.spawnerControler._spawner.SpawnerCount;
        return currentJunk >= this.randomLimit;
    }
}
