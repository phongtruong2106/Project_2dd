using UnityEngine;

public abstract class ItemAbstract : NewMonobehavior
{
    
    [Header("Junk Abstract")]
    [SerializeField] protected ItemControler itemControler;
    public ItemControler _itemControler => itemControler; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemControler();
    }

    protected virtual void LoadItemControler()
    {
        if(this.itemControler != null) return;
        this.itemControler = transform.parent.GetComponent<ItemControler>();
        Debug.Log(transform.name + ": LoadItemControler", gameObject);
    }
}