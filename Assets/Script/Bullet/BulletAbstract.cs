using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : NewMonobehavior
{
    [Header("Bullet Abstract")]
    [SerializeField] protected BulletControler bulletControler;
    public BulletControler BulletControler{get => bulletControler;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if(this.bulletControler != null) return;
        this.bulletControler = transform.parent.GetComponent<BulletControler>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }
}
