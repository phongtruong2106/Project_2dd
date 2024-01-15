using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : NewMonobehavior
{
    [SerializeField] protected JunkSpawnerControler junkSpawnerControler;
    [SerializeField] protected float randomTimer = 1f;
    [SerializeField] protected float randomDelay = 0f;
    [SerializeField] protected float randomLimit = 9f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkControler();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.randomDelay = 1f;
        this.randomTimer = 0f;
        this.randomLimit = 9f;
    }

    protected virtual void LoadJunkControler()
    {
        if(this.junkSpawnerControler != null) return;
        this.junkSpawnerControler = GetComponent<JunkSpawnerControler>();
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

        Transform ranPoint = this.junkSpawnerControler.SpawnPoint.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion ros = transform.rotation;

        Transform prefab = this.junkSpawnerControler.JunkSpawner.RandomPrefab();
        Transform obj =  this.junkSpawnerControler.JunkSpawner.Spawn(prefab, pos, ros);
        obj.gameObject.SetActive(true);
        // Invoke(nameof(this.JunkSpawning), 1f);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnerControler.JunkSpawner.SpawnerCount;
        return currentJunk >= this.randomLimit;
    }
}
