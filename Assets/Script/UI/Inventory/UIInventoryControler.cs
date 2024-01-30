using UnityEngine;

public class UIInventoryControler : NewMonobehavior
{
    [SerializeField] protected Transform content;
    public Transform _content => content;

    [Header("Inventory Item Spawner")]
    [SerializeField] protected UIInventorySpawner uIInventorySpawner;
    public UIInventorySpawner _uIInventorySpawner => uIInventorySpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIInventorySpawner();  
    }
    protected virtual void LoadContent()
    {
        if(this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.LogWarning(transform.name + ": LoadContent", gameObject);
    }
    protected virtual void LoadUIInventorySpawner()
    {
        if(this.uIInventorySpawner != null) return;
        this.uIInventorySpawner = transform.GetComponentInChildren<UIInventorySpawner>();
        Debug.LogWarning(transform.name + ": LoadUIInventorySpawner", gameObject);
    }
}