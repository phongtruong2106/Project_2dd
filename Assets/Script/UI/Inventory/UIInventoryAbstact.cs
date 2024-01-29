using UnityEngine;

public abstract class UIInventoryAbstact : NewMonobehavior
{
    [Header("UI Inventory Abstract")]
    [SerializeField] protected UIInventoryControler uIInventoryControler;
    public UIInventoryControler _uIInventoryControler => uIInventoryControler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryControler();
    }
    protected virtual void LoadUIInventoryControler()
    {
        if(this.uIInventoryControler != null) return;
        this.uIInventoryControler = transform.parent.GetComponent<UIInventoryControler>();
        Debug.LogWarning(transform.name + ": LoadUIInventoryControler", gameObject);
    }
}