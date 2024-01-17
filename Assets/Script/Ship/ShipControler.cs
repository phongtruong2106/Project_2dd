using UnityEngine;

public class ShipControler : NewMonobehavior
{
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if(this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + ": LoadIventory", gameObject);
    }
}