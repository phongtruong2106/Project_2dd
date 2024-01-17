using System;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class ItemPickupAble : ItemAbstract
{
    [Header("Item Pickupable")]
    [SerializeField] protected SphereCollider _collider;

    //giai thuat chuyen doi kieu enum -> string
    public static ItemCode String2ItemCode(string itemName)
    {
        try
        {
            return (ItemCode)Enum.Parse(typeof(ItemCode), itemName);
        }
        catch(ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }

   protected virtual void LoadTrigger()
    {
        if (this._collider == null)
        {
            this._collider = transform.GetComponent<SphereCollider>();
            this._collider.isTrigger = true;
            this._collider.radius = 0.2f;
            Debug.Log(transform.name + ": LoadIsTrigger", gameObject);
        }
    }
    public virtual ItemCode GetItemCode()
    {
        return ItemPickupAble.String2ItemCode(transform.parent.name);
    }

    public virtual void Pickup()
    {
        this.itemControler._itemDespawn.DespawnObject();
    }
 
    public virtual void OnMouseDown()
    {
        PlayerControler.Instance.PlayerPickup.ItemPickup(this);
    }
}