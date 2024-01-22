using UnityEngine;

public class ShipShootingByDistance : ObjectShooting
{
    [Header("Shoot bu distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float shootDistance = 3f;
    [SerializeField] protected float distance = Mathf.Infinity;

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override bool IsShooting()
    { 
        this.distance = Vector3.Distance(transform.position, this.target.position);
        this.isShooting = this.distance < this.shootDistance;
        return this.isShooting;
    }
}
