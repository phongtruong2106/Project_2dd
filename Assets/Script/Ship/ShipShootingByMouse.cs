using UnityEngine;

public class ShipShootingByMouse : ShipShooting
{
    protected override bool IsShooting()
    { 
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}