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
        this.OnDeadFX();
        this.OnDeadDrop();
        this.junkControler.JunkDespawn.DespawnObject(); 
   
    }

    protected virtual void OnDeadDrop()
    {
             //Drop here
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkControler._shootAbleObject.dropList, dropPos, dropRot);
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.SmokeOne;
    }

    public override void Reborn()
    {
        this.maxHp = this.junkControler._shootAbleObject.hpMax;
        base.Reborn();
    }
}
