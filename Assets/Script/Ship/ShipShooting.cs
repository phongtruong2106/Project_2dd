using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected Transform bulletPrefab;
    
    private void Update() {
        this.IsShooting();
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if(!this.isShooting) return;
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Instantiate(this.bulletPrefab, spawnPos, rotation);
        Debug.Log("Shooting");
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
