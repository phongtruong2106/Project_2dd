using UnityEngine;

public abstract class BaseAbility : NewMonobehavior
{
    [Header("Base Ability")]
    [SerializeField] protected float timer = 2f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isRead = false;

    protected virtual void FixedUpdate()
    {
        this.Timing();
    }

    protected virtual void Timing()
    {
        if(this.isRead) return;
        this.timer += Time.fixedDeltaTime;
        if(this.timer < this.delay) return;
        this.isRead = true;
    }

    public virtual void Active()
    {
        this.isRead = false;
        this.timer = 0;
    }
}