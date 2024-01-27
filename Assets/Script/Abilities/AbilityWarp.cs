using UnityEngine;

public class AbilityWarp : BaseAbility
{
    [Header("Ability Warp")]
    [SerializeField] protected Spawner spawner;  
    protected Vector4 keyDirection;
    [SerializeField] protected bool isWarping = false;
    [SerializeField] protected Vector4 warpDirection;
    [SerializeField] protected float warpSpeed = 1f;
    [SerializeField] protected float warpDistance = 2f;

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
        this.MoveObj();
        this.warpDirection.Set(0,0,0,0);
        this.isWarping = false;
        this.Active();
    }

    protected virtual void MoveObj()
    {
        Transform  obj = this.abilities._abilityObjectControler.transform;
        Vector3 newPos = obj.position;
        if(this.warpDirection.x == 1) newPos.x -= this.warpDistance;
        if(this.warpDirection.y == 1) newPos.x += this.warpDistance;
        if(this.warpDirection.z == 1) newPos.y += this.warpDistance;
        if(this.warpDirection.w == 1) newPos.y -= this.warpDistance;

        Quaternion fxRot = this.GetFXQuaternion();
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.impactOne, obj.position,fxRot);
        fx.gameObject.SetActive(true);
        obj.position = newPos;
    }
    protected virtual Quaternion GetFXQuaternion()
    {
        Vector3 vector = new Vector3();
        if(this.warpDirection.x == 1) vector.z = 0;
        if(this.warpDirection.y == 1) vector.z = 180;
        if(this.warpDirection.z == 1) vector.z = -90;
        if(this.warpDirection.w == 1) vector.z = 90;

        if(this.warpDirection.x == 1 && this.warpDirection.w == 1) vector.z = 45;
        if(this.warpDirection.y == 1 && this.warpDirection.w == 1) vector.z = 135;
        if(this.warpDirection.z == 1 && this.warpDirection.z == 1) vector.z = -45;
        if(this.warpDirection.w == 1 && this.warpDirection.z == 1) vector.z = -145;
        return Quaternion.Euler(vector);
    }
}