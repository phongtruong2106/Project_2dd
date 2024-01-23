using UnityEngine;

public class MotherShipModify : ObjectModifyAbstract
{
    [Header("Mother Ship")]
    [SerializeField] protected float speed = 0.005f;
    [SerializeField] protected float rotSpeed = 0.01f;

    protected override void Start()
    {
        base.Start();
        this.ShipModify();
    }

    protected virtual void ShipModify()
    {
        this.shootAbleObjectControler._objectMovement.SetSpeed(this.speed);
        this.shootAbleObjectControler._objectLookAtTarget.SetRotSpeed(this.rotSpeed);
    }
}