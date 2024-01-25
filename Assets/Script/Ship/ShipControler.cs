using UnityEngine;

public class ShipControler : AbilityObjectControler
{
    [Header("Ship")]
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override string GetObjectTypeString()
    {
        return ObjectType.Ship.ToString();
    }

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