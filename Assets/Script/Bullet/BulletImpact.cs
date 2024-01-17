using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigibody();
    }

    protected virtual void LoadCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {

        if(other.transform.parent == this.bulletControler.Shooter) return;

        this.bulletControler.DamageSender.Send(other.transform);
       
    }

    // protected virtual void createFXImpact(Collider other)
    // {
    //     string fxName = this.GetImpactFX();

    //     Vector3 hitPos = transform.position;
    //     Quaternion hitRot = transform.rotation;
    //     Transform fxImpact =  FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
    //     fxImpact.gameObject.SetActive(true);

    // }

    // protected virtual string GetImpactFX()
    // {
    //     return FXSpawner.impactOne;
    // }
}
