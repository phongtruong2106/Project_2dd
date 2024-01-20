using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootAbleObjectDamageReceiver : DamageReceiver
{
    [Header("ShootAble Object")]
    [SerializeField] protected ShootAbleObjectControler shootAbleObjectControler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadControler();
        this.Reborn();//
    }

    protected virtual void LoadControler()
    {
        if(this.shootAbleObjectControler != null) return;
        this.shootAbleObjectControler = transform.parent.GetComponent<ShootAbleObjectControler>();
        Debug.Log(transform.name + ": LoadJunkControler", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.shootAbleObjectControler._despawn.DespawnObject(); 
   
    }

    protected virtual void OnDeadDrop()
    {
             //Drop here
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootAbleObjectControler._shootAbleObject.dropList, dropPos, dropRot);
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
        this.maxHp = this.shootAbleObjectControler._shootAbleObject.hpMax;
        base.Reborn();
    }
}
