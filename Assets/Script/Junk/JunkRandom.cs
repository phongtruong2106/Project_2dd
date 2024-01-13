using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : NewMonobehavior
{
    [SerializeField] protected JunkControler junkControler;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkControler();
    }

    protected virtual void LoadJunkControler()
    {
        if(this.junkControler != null) return;
        this.junkControler = GetComponent<JunkControler>();
        Debug.Log(transform.name + ": LoadJunkControler", gameObject);
    }


    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.junkControler.SpawnPoint.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion ros = transform.rotation;
        Transform obj =  this.junkControler.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, ros);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
