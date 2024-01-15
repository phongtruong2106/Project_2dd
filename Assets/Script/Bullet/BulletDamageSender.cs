using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletControler bulletControler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletControler();
    }

    protected virtual void LoadBulletControler()
    {
        if(this.bulletControler != null) return;
        this.bulletControler = transform.parent.GetComponent<BulletControler>();
        Debug.Log(transform.name + ": LoadBulletControler", gameObject);
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        this.bulletControler.BulletDespawn.DespawnObject();
    }
}
