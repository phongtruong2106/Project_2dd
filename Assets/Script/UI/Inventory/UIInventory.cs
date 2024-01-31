using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstact
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory _instance => instance;

    protected bool isOpen = true;
    //protected bool isSorting = false;
    [SerializeField] protected UIInventorySort inventorySort = UIInventorySort.ByName;


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
        InvokeRepeating(nameof(this.ShowItems), 1, 1);
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

    protected virtual void ShowItems()
    {
        if(!this.isOpen) return;
        this.ClearItem();
        List<ItemInventory> items = PlayerControler.Instance.CurrentShip.Inventory.Items; 
        UIInventorySpawner spawner = this._uIInventoryControler._uIInventorySpawner;
        foreach(ItemInventory item in items)
        {
            spawner.SpawnItems(item);
        }

        this.SortItems();
    }

    protected virtual void ClearItem()
    {
        this._uIInventoryControler._uIInventorySpawner.ClearItems();
    }

    protected virtual void SortItems()
    {
        switch(this.inventorySort)
        {
            case UIInventorySort.ByName:
                this.SortByName();
                break;
            case UIInventorySort.ByCount:
                Debug.Log("UIInventorySort.ByCount");
                break;
            default:
                Debug.Log("UIInventorySort.NoSort");
                break;
        }
    }

    protected virtual void SortByName()
    {
        Debug.Log("===== Sort By Name-=====   ");
        int itemCount = this._uIInventoryControler._content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        ItemProfileSO currentProfile, nextProfile;
        String currentName, nextName;

        for(int i = 0; i < itemCount - 1; i++)
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
                ///isSorting = true;
            }

            Debug.Log(i+ ": " + currentName + " | " + nextName + " = " + compare);
        }

        //de Quy
        //if(isSorting) this.SortByName();
    }
    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(currentIndex);
        nextItem.SetSiblingIndex(nextIndex);
    }
}