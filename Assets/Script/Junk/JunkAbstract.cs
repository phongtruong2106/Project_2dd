using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : NewMonobehavior
{
    [SerializeField] protected JunkControler junkControler;
    public JunkControler JunkControler {get => junkControler;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkControler();
    }

    protected virtual void LoadJunkControler()
    {
        if(this.junkControler != null) return;
        this.junkControler = transform.parent.GetComponent<JunkControler>();
        Debug.Log(transform.name + ": LoadJunkControler", gameObject);
    }
}
