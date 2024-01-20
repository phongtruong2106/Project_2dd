using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkControler : NewMonobehavior
{
    [SerializeField] protected Transform model;
    public Transform Model{get => model;}
    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn {get => junkDespawn;}
    [SerializeField] protected ShootAbleObjectSO shootAbleObject;
    public ShootAbleObjectSO _shootAbleObject => shootAbleObject;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDesqawn();
        this.LoadJunkSO();
    }

    protected virtual void LoadModel()
    {
        if(this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadJunkDesqawn()
    {
        if(this.junkDespawn != null) return;
        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": LoadJunkDespawn", gameObject);
    }

    protected virtual void LoadJunkSO()
    {
        if(this.shootAbleObject != null)return;
        string resPath ="ShootAbleObject/Junk/" + transform.name;
        this.shootAbleObject = Resources.Load<ShootAbleObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadJunkSO " + resPath, gameObject);
    }
}
