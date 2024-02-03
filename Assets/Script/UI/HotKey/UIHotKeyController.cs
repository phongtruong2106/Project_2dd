using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyController : NewMonobehavior
{
    private static UIHotKeyController instance;
    public static UIHotKeyController _instance {get => instance;}

    public List<ItemSlot> itemSlots; 

    protected override void Awake()
    {
        if(UIHotKeyController.instance != null) Debug.LogError("Only one UIHotKeyController allow to exist");
        UIHotKeyController.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSlots();
    }

    protected virtual void LoadItemSlots()
    {
        if(this.itemSlots.Count > 0) return;
        ItemSlot[] arraySlot = GetComponentsInChildren<ItemSlot>();
        this.itemSlots.AddRange(arraySlot);
        Debug.LogWarning(transform.name + ": LoadContent", gameObject);
    }
}