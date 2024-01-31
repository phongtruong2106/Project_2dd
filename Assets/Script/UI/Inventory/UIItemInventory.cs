using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : NewMonobehavior
{   
    [Header("UI Item Inventory")]
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory _itemInventory => itemInventory;
    [SerializeField] protected Text itemName;
    public Text _itemName => itemName;
    [SerializeField] protected Text itemNumber;
    public Text _itemNumber => itemNumber;

    [SerializeField] protected Image itemSprite;
    public Image _itemSprite => itemSprite;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemCount();
        this.LoadItemSprite();
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
    protected virtual void LoadItemSprite()
    {
        if(this.itemSprite != null) return;
        this.itemSprite = transform.Find("ItemImage").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemSprite", gameObject);
    }
    public virtual void ShowItem(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.text = this.itemInventory.itemProfile.itemName;
        this.itemNumber.text = this.itemInventory.itemCount.ToString();
        this.itemSprite.sprite = this.itemInventory.itemProfile.sprite;
    }
}