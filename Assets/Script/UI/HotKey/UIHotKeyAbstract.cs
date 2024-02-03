using System.Collections.Generic;
using UnityEngine;

public abstract class UIHotKeyAbstract : NewMonobehavior
{
    [SerializeField] protected UIHotKeyController hotKeyController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIHotKeyController();
    }

    protected virtual void LoadUIHotKeyController()
    {
        if(this.hotKeyController != null) return;
        this.hotKeyController = transform.parent.GetComponent<UIHotKeyController>();
        Debug.LogWarning(transform.name + ": LoadUIHotKeyController", gameObject);
    }
}