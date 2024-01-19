using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : InventoryAbstract
{
    [SerializeField] protected SphereCollider _Collider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadTrigger();
        this.LoadRigidbody();
    }

    protected virtual void LoadTrigger()
    {
        if(this._Collider != null) return;
        this._Collider = transform.GetComponent<SphereCollider>();
        this._Collider.isTrigger = true;
        this._Collider.radius = 0.2f;   
        Debug.Log(transform.name + ": LoadIsTrigger", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if(this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.useGravity= false;
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemPickupAble itemPickupAble = other.GetComponent<ItemPickupAble>();
        if(itemPickupAble == null) return;
        ItemInventory itemInventory = itemPickupAble._itemControler._itemInventory;
        if(this.inventory.AddItem(itemInventory))
        {
            itemPickupAble.Pickup();
        }
    }
}