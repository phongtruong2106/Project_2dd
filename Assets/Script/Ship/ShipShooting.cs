using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected Transform bulletPrefab;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 1f;
    
    private void Update() {
        this.IsShooting();   
        
    }
    private void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if(!this.isShooting) return;

        this.shootTimer += Time.fixedDeltaTime;
        if(this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

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
