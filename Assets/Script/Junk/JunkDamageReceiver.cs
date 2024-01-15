using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JunkDamageRecever : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkControler junkControler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkControler();
        this.Reborn();//
    }

    protected virtual void LoadJunkControler()
    {
        if(this.junkControler != null) return;
        this.junkControler = transform.parent.GetComponent<JunkControler>();
        Debug.Log(transform.name + ": LoadJunkControler", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        this.junkControler.JunkDespawn.DespawnObject();
    }

    public override void Reborn()
    {
        this.maxHp = this.junkControler.JunkSO.hpMax;
        base.Reborn();
    }
}
