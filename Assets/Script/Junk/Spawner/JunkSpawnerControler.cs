using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerControler : NewMonobehavior
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner {get => junkSpawner;}
    
    [SerializeField] protected SpawnPoint spawnPoints;
    public SpawnPoint SpawnPoint {get => spawnPoints;}
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadJunkSpawner()
    {
        if(this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    
    protected virtual void LoadSpawnPoint()
    {
        if(this.spawnPoints != null) return;
        this.spawnPoints = Transform.FindAnyObjectByType<SpawnPoint>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
