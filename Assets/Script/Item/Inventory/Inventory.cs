using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : NewMonobehavior
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;

    protected override void Start()
    {
        base.Start(); 
        this.AddItem(ItemCode.Sword, 1);
        this.AddItem(ItemCode.IronOre, 30);
        this.AddItem(ItemCode.GoldOre, 30);
       
    }
    public virtual bool AddItem(ItemInventory itemInventory)
    {
        int addCount = itemInventory.itemCount;
        ItemProfileSO itemProfileSO = itemInventory.itemProfile;
        ItemCode itemCode = itemInventory.itemProfile.itemCode;
        ItemType itemType = itemProfileSO.itemType;

        if(itemType == ItemType.Equiment) return this.AddEquiment(itemInventory);  
        return this.AddItem(itemCode, addCount);
    }

    public virtual bool AddEquiment(ItemInventory itemInventory)
    {
        if(this.IsInventoryFull()) return false;
        this.items.Add(itemInventory);
        return true;
    }
    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfileSO = this.GetItemProfile(itemCode);
        int addRemain = addCount;
        int newCOunt;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if(itemExist == null)
            {
                if(this.IsInventoryFull()) return false;
                itemExist = this.CreateEmptyItem(itemProfileSO);
                this.items.Add(itemExist);
            }
            newCOunt = itemExist.itemCount + addRemain;

            itemMaxStack = this.GetMaxStack(itemExist);

            if(newCOunt > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCOunt = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCOunt;
            }

            itemExist.itemCount = newCOunt;
            if(addRemain < 1) break;
        }

        // ItemInventory itemInventory = this.GetItemByCode(itemCode);
        // int newCount = itemInventory.itemCount + addCount;
        // if(newCount > itemInventory.maxStack) return false;
        
        // itemInventory.itemCount = newCount;
        return true;
    }

    protected virtual bool IsInventoryFull()
    {
        if(this.items.Count >= this.maxSlot) return true;
        return false;
    }

    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if(itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {   
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if(profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }
    // public virtual bool DeductItem(ItemCode itemCode, int addCount)
    // {
    //     ItemInventory itemInventory = this.GetItemByCode(itemCode);
    //     int newCount = itemInventory.itemCount - addCount;
    //     if(newCount < 0) return false;

    //     itemInventory.itemCount = newCount;
    //     return true;
    // }

    public virtual bool TryDeductItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - addCount;
        if(newCount < 0) return false;
        return true;
    }

    public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((x) => x.itemProfile.itemCode == itemCode);
        if(itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if(itemCode != itemInventory.itemProfile.itemCode) continue;
            if(this.IsFullStack(itemInventory)) continue;
            return itemInventory;
        }

        return null;
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if(itemInventory == null) return true;
        
        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }

    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if(profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }

        return null;
    }

    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };

        return itemInventory;
    }

    public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= numberCheck;
    }

    public virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory itemInventory in this.items)
        {
            if(itemInventory.itemProfile.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;
        }
        
        return totalCount;
    }

    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for (int i = this.items.Count-1; i >= 0; i--)
        {
            if(deductCount <= 0) break;

            itemInventory = this.items[i];
            if(itemInventory.itemProfile.itemCode != itemCode) continue;

            if(deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }

            itemInventory.itemCount -= deduct;
        }
        this.ClearEmptySlot();
    }

    protected virtual void ClearEmptySlot()
    {
        ItemInventory itemInventory;
        for (int i = 0; i < this.items.Count; i++)
        {
            itemInventory = this.items[i];
            if(itemInventory.itemCount == 0) this.items.RemoveAt(i);
        }
    }
}