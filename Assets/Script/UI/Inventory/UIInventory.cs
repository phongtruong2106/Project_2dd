using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstact
{
   [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory _instance => instance;

    protected bool isOpen = true;
    [SerializeField] protected UIInventorySort inventorySort = UIInventorySort.ByName;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.ShowItems), 1, 1);
    }

    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
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

    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;

        this.ClearItems();

        List<ItemInventory> items = PlayerControler.Instance.CurrentShip.Inventory.Items;
        UIInventorySpawner spawner = this._uIInventoryControler._uIInventorySpawner;

        foreach (ItemInventory item in items)
        {
            spawner.SpawnItems(item);
        }

        this.SortItems();
    }

    protected virtual void ClearItems()
    {
        this._uIInventoryControler._uIInventorySpawner.ClearItems();
    }

    protected virtual void SortItems()
    {
        switch (this.inventorySort)
        {
            case UIInventorySort.ByName:
                this.SortByName();
                break;
            case UIInventorySort.ByCount:
                Debug.Log("InventorySort.ByCount");
                break;
            default:
                Debug.Log("InventorySort.NoSort");
                break;
        }
    }

    protected virtual void SortByName()
    {
        Debug.Log("== InventorySort.ByName ====");

        int itemCount = this._uIInventoryControler._content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        ItemProfileSO currentProfile, nextProfile;
        string currentName, nextName;

        bool isSorting = false;
        for (int i = 0; i < itemCount - 1; i++)
        {
            currentItem = this._uIInventoryControler._content.GetChild(i);
            nextItem = this._uIInventoryControler._content.GetChild(i + 1);

            currentUIItem = currentItem.GetComponent<UIItemInventory>();
            nextUIItem = nextItem.GetComponent<UIItemInventory>();

            currentProfile = currentUIItem._itemInventory.itemProfile;
            nextProfile = nextUIItem._itemInventory.itemProfile;

            currentName = currentProfile.itemName;
            nextName = nextProfile.itemName;

            int compare = string.Compare(currentName, nextName);

            if(compare == 1)
            {
                this.SwapItems(currentItem, nextItem);
                isSorting = true;
            }

            Debug.Log(i + ": " + currentName + " | " + nextName + " = " + compare);
        }

        if (isSorting) this.SortByName();
    }

    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }
}