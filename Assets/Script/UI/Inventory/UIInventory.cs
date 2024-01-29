using UnityEngine;

public class UIInventory : NewMonobehavior
{
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
    }

    protected virtual void FixedUpdate()
    {
        this.ShowItem();
    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if(this.isOpen) this.Open();
        else this.Close();

    }
    public virtual void Open()
    {
        gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItem()
    {
        if(!this.isOpen) return;
        float itemCount = PlayerControler.Instance.CurrentShip.Inventory.Items.Count;
        Debug.Log("ItemCount: " + itemCount);
     }
}