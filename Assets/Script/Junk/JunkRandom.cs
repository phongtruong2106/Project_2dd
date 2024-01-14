using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : NewMonobehavior
{
    [SerializeField] protected JunkSpawnerControler junkSpawnerControler;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkControler();
    }

    protected virtual void LoadJunkControler()
    {
        if(this.junkSpawnerControler != null) return;
        this.junkSpawnerControler = GetComponent<JunkSpawnerControler>();
        Debug.Log(transform.name + ": LoadJunkControler", gameObject);
    }


    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.junkSpawnerControler.SpawnPoint.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion ros = transform.rotation;
        Transform obj =  this.junkSpawnerControler.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, ros);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
