using UnityEngine;

public abstract class ShootAbleObjectAbstract : NewMonobehavior
{
    [SerializeField] protected ShootAbleObjectControler shootAbleObjectControler;
    public ShootAbleObjectControler _shootAbleObjectControler => shootAbleObjectControler;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootAbleObjectControler();
    }

    protected virtual void LoadShootAbleObjectControler()
    {
        if(this.shootAbleObjectControler != null) return;
        this.shootAbleObjectControler = transform.parent.GetComponent<ShootAbleObjectControler>();
        Debug.Log(transform.name + ": shootAbleObjectControler", gameObject);
    }
}