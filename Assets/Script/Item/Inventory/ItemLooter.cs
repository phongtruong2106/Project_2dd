using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : NewMonobehavior
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected SphereCollider _Collider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadTrigger();
        this.LoadRigidbody();
    }

    protected virtual void LoadInventory()
    {
       if(this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.Log(transform.name + ": LoadInventory", gameObject);
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

        ItemCode itemCode = itemPickupAble.GetItemCode();
        if(this.inventory.AddItem(itemCode, 1))
        {
            itemPickupAble.Pickup();
        }
    }
}