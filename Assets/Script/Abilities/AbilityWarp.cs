using UnityEngine;

public class AbilityWarp : BaseAbility
{
    [Header("Ability Warp")]
    [SerializeField] protected Spawner spawner;  
    protected Vector4 keyDirection;
    [SerializeField] protected bool isWarping = false;
    [SerializeField] protected Vector4 warpDirection;
    [SerializeField] protected float warpSpeed = 1f;

    protected override void Update()
    {
        base.Update();
        this.CheckWarpDirection();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Warping();
    }

    protected virtual void CheckWarpDirection()
    {   
        if(!this.isReady) return;
        if(this.isWarping) return;

        if(this.keyDirection.x == 1) WarpLeft();
        if(this.keyDirection.y == 1) WarpRight();
        if(this.keyDirection.z == 1) WarpUp();
        if(this.keyDirection.w == 1) WarpDown();
    }

    protected virtual void WarpLeft()
    {
        Debug.Log("warpLeft");
        this.warpDirection.x = 1;
    }
    protected virtual void WarpRight()
    {
        Debug.Log("WarpRight");
        this.warpDirection.y = 1;
    }
    protected virtual void WarpUp()
    {
        Debug.Log("WarpUp");
        this.warpDirection.z = 1;
    }
    protected virtual void WarpDown()
    {
        Debug.Log("WarpDown");
        this.warpDirection.w = 1;
    }
    protected virtual void Warping()
    {   
        if(this.isWarping) return;
        if(this.IsDirectionNotSet()) return;

        Debug.LogWarning("Warping");
        Debug.LogWarning(this.warpDirection);

        this.isWarping = true;
        Invoke(nameof(this.WarpFinish), this.warpSpeed);
    }

    protected virtual bool IsDirectionNotSet()
    {
        return this.warpDirection.x == 0 && this.warpDirection.y == 0
            && this.warpDirection.z == 0 && this.warpDirection.w == 0;
    }

    protected virtual void WarpFinish()
    {
        Debug.LogWarning("<b> WarpFinish <b>");
        this.warpDirection.Set(0,0,0,0);
        this.isWarping = false;
        this.Active();
    }
}