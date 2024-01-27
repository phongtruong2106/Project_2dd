using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : NewMonobehavior
{
    [Header("Damage Receiver")]
    [SerializeField] protected SphereCollider sphereCollider; 
    [SerializeField] protected int hp = 1;
    public int _hp => hp;
    [SerializeField] protected int maxHp = 1;
    public int _maxHp => maxHp;
    [SerializeField] protected bool isDead = false;

    protected override void OnEnable()
    {
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();  
    }

    protected virtual void LoadCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.27f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    public virtual void Reborn()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }

    public virtual void Add(int add)
    {
         if(this.isDead) return;
        this.hp += add;
        if(this.hp > this.maxHp) this.hp = this.maxHp;
    }

    public virtual void Deduct(int deduct)
    {
        if(this.isDead) return;
        this.hp -= deduct;
        if(this.hp < 0) this.hp = 0;
        this.CheckIsDead();

    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if(!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}
