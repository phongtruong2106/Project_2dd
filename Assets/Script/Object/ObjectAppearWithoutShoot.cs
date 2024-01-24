
using UnityEngine;

public class ObjectAppearWithoutShoot : ShootAbleObjectAbstract, IObjectAppearObserver
{
    [Header("Object Appear Without Shoot")]
    [SerializeField] protected ObjectAppearing objectAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterApperEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectAppearing();
    }

    
    protected virtual void LoadObjectAppearing()
    {
        if(this.objectAppearing != null) return;
        this.objectAppearing = GetComponent<ObjectAppearing>();
        Debug.Log(transform.name + ": LoadObjectAppearing", gameObject);
    }

    protected virtual void RegisterApperEvent()
    {
        this.objectAppearing.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        this.shootAbleObjectControler._objectShooting.gameObject.SetActive(false);
        this.shootAbleObjectControler._objectLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.shootAbleObjectControler._objectShooting.gameObject.SetActive(true);
        this.shootAbleObjectControler._objectLookAtTarget.gameObject.SetActive(true);
    }
}