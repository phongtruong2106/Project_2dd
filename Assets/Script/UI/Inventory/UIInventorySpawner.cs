using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventorySpawner : Spawner
{
    
    protected static UIInventorySpawner instance;
    public static UIInventorySpawner _instance => instance;
    [Header("Inventory Item Spawner")]
    [SerializeField] protected UIInventoryControler uIInventoryControler;
    public UIInventoryControler _uIInventoryControler => uIInventoryControler;

    public static string normalItem = "UIInventoryItem";

    protected override void Awake() 
    {
        base.Awake();
        if(UIInventorySpawner.instance != null) Debug.LogError("Only one UIInventorySpawner allow to exist");
        UIInventorySpawner.instance = this;
        
    }

    protected override void LoadHodler()
    {
        this.LoadUIInventoryControler();
        if(this.holder != null) return;
        this.holder = this._uIInventoryControler._content;
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadUIInventoryControler()
    {
        if(this.uIInventoryControler != null) return;
        this.uIInventoryControler = transform.parent.GetComponent<UIInventoryControler>();
        Debug.LogWarning(transform.name + ": UIInventoryControler", gameObject);
    }

    public virtual void ClearItems()
    {
        foreach(Transform item in this.holder)
        {
            this.Despawn(item);
        }
    }

    public virtual void SpawnItems(ItemInventory item)
    {   
        
        Transform uiItem = this._uIInventoryControler._uIInventorySpawner.Spawn(UIInventorySpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1,1,1);

        UIItemInventory iItemInventory = uiItem.GetComponent<UIItemInventory>();
        iItemInventory.ShowItem(item);
        uiItem.gameObject.SetActive(true);
        
    }
}
