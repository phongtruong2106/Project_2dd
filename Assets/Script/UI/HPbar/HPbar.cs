using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPbar: NewMonobehavior
{
    [Header("HPbar")]
    [SerializeField] protected ShootAbleObjectControler shootAbleObjectControler;
    [SerializeField] protected SliderHP sliderHP; 
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;

    protected virtual void FixedUpdate()
    {
        // this.CheckTargetIsDead();
        this.ShowHP();
        
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }

    protected virtual void LoadSliderHP()
    {
        if(this.sliderHP != null) return;
        this.sliderHP = transform.GetComponentInChildren<SliderHP>();
        Debug.LogWarning(transform.name + ": LoadSliderHP", gameObject);
    }
    protected virtual void LoadFollowTarget()
    {
        if(this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadFollowTarge", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if(this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    // protected virtual void CheckTargetIdDead()
    // {
    //     bool isDead = this.shootAbleObjectControler._damageReceiver.IsDead();
    //     if(isDead) this.spawner.Despawn(transform);
    //     return;
    // }

    protected virtual void ShowHP()
    {
        if(this.shootAbleObjectControler == null) return;
        bool isDead = this.shootAbleObjectControler._damageReceiver.IsDead();
        if(isDead)
        {
            this.spawner.Despawn(transform);
            return;
        } 
       float hp = this.shootAbleObjectControler._damageReceiver._hp;
       float maxHP = this.shootAbleObjectControler._damageReceiver._maxHp;

       this.sliderHP.SetCurrentHP(hp);
       this.sliderHP.SetMaxHP(maxHP);

    }

    public virtual void SetObjectControler(ShootAbleObjectControler shootAbleObjectControler)
    {
        this.shootAbleObjectControler = shootAbleObjectControler;
    }

    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
}