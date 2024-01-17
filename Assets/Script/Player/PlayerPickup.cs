using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupAble itemPickupAble)
    {
        Debug.Log("ItemPickup");

        ItemCode itemCode = itemPickupAble.GetItemCode();
        if(this.playerControler.CurrentShip.Inventory.AddItem(itemCode, 1))
        {
            itemPickupAble.Pickup();
        }
    }
}