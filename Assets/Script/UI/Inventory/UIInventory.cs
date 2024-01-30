using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstact
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory _instance => instance;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if(UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to ");
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        //this.Close();
        InvokeRepeating(nameof(this.ShowItem), 1, 1);
    }

    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if(this.isOpen) this.Open();
        else this.Close();

    }
    public virtual void Open()
    {
        this._uIInventoryControler.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        this._uIInventoryControler.gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItem()
    {
        if(!this.isOpen) return;
        this.ClearItem();
        List<ItemInventory> items = PlayerControler.Instance.CurrentShip.Inventory.Items; 
        UIInventorySpawner spawner = this._uIInventoryControler._uIInventorySpawner;
        foreach(ItemInventory item in items)
        {
            spawner.SpawnItems(item);
        }
    }

    protected virtual void ClearItem()
    {
        this._uIInventoryControler._uIInventorySpawner.ClearItems();
    }

}