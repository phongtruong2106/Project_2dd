using UnityEngine;

public class ObjectModifyAbstract : NewMonobehavior
{
    [Header("Modify")]
    [SerializeField] protected ShootAbleObjectControler shootAbleObjectControler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.shootAbleObjectControler != null) return;
        this.shootAbleObjectControler = transform.GetComponent<ShootAbleObjectControler>();
        Debug.LogWarning(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }
}