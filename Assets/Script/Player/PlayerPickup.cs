using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupAble itemPickupAble)
    {
        Debug.Log("ItemPickup");

        ItemCode itemCode = itemPickupAble.GetItemCode();
        ItemInventory itemInventory = itemPickupAble._itemControler._itemInventory;
        if(this.playerControler.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupAble.Pickup();
        }
    }
}