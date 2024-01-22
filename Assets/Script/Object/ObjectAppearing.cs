using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAppearing : NewMonobehavior
{
    [Header("Object Appearing")]
    [SerializeField] protected bool isAppearing = false;
    [SerializeField] protected bool appeared = false;
    [SerializeField] protected List<IObjectAppearObserver> observers = new List<IObjectAppearObserver>();
    public bool _isAppearing => isAppearing;
    public bool _appeared => appeared;

    protected override void Start()
    {
        base.Start();
        this.OnAppearStart();
    }
    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected abstract void Appearing();

    public virtual void Appear()
    {
        this.appeared = true;
        this.isAppearing = false;
        this.OnAppearFinish();
    }
    
    public virtual void ObserverAdd(IObjectAppearObserver objectAppearObserver)
    {
        this.observers.Add(objectAppearObserver);
    }

    protected virtual void OnAppearStart()
    {
        foreach(IObjectAppearObserver observer in this.observers)
        {
            observer.OnAppearStart();
        }
    }

    protected virtual void OnAppearFinish()
    {
        foreach(IObjectAppearObserver observer in this.observers)
        {
            observer.OnAppearFinish();
        }
    }
}