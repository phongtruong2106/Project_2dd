using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if(ItemDropSpawner.instance != null) Debug.LogError("Only one FXSpawner allow to exist");
        ItemDropSpawner.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        //TODO: Drop with rating
        if(dropList.Count < 1) return;
        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if(itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }

    public virtual Transform Drop(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = itemInventory.itemProfile.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if(itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);

        ItemControler itemControler = itemDrop.GetComponent<ItemControler>();
        itemControler.SetItemInventory(itemInventory);
        return itemDrop;
    }
}