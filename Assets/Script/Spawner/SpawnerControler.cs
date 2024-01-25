using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControler : NewMonobehavior
{
    [SerializeField] protected Spawner spawner;
    public Spawner _spawner => spawner;
    
    [SerializeField] protected SpawnPoint spawnPoints;
    public SpawnPoint SpawnPoint {get => spawnPoints;}
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawner()
    {
        if(this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    
    protected virtual void LoadSpawnPoint()
    {
        if(this.spawnPoints != null) return;
        this.spawnPoints = GameObject.Find("SceneSpawnPoint").GetComponent<SpawnPoint>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
