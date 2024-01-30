using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : NewMonobehavior
{
    [Header("UI Item Inventory")]

    [SerializeField] protected Text itemName;
    public Text _itemName => itemName;
    [SerializeField] protected Text itemNumber;
    public Text _itemNumber => itemNumber;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemCount();
    }

    protected virtual void LoadItemName()
    {
        if(this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadItemCount()
    {
        if(this.itemNumber != null) return;
        this.itemNumber = transform.Find("ItemCount").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemCount", gameObject);
    }

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemName.text = item.itemProfile.itemName;
        this.itemNumber.text = item.itemCount.ToString();
    }
}