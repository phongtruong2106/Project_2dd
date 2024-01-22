using UnityEngine;

public abstract class ObjectShooting : NewMonobehavior 
{
    [SerializeField] protected bool isShooting = false;
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
       // Transform newBullet = Instantiate(this.bulletPrefab, spawnPos, rotation);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if(newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        BulletControler bulletControler =newBullet.GetComponent<BulletControler>();
        bulletControler.SetShooter(transform.parent);
    }

    protected abstract bool IsShooting();
}
