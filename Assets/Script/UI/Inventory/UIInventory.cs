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
        float itemCount = PlayerControler.Instance.CurrentShip.Inventory.Items.Count;
        for(int i = 1; i <= itemCount; i++)
        {
            this.SpawnTest(i);
        }
        Debug.Log("ItemCount: " + itemCount);
    }

    protected virtual void ClearItem()
    {
        this._uIInventoryControler._uIInventorySpawner.ClearItems();
    }

    protected virtual void SpawnTest(int i)
    {
        Transform uiItem = this._uIInventoryControler._uIInventorySpawner.Spawn(UIInventorySpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1,1,1);
        uiItem.gameObject.SetActive(true);
    }
}