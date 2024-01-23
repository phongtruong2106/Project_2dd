using UnityEngine;

public abstract class ShootAbleObjectControler : NewMonobehavior
{
    [Header("Shootable Object")]
    [SerializeField] protected Transform model;
    public Transform _model => model;
    [SerializeField] protected DesSpawn despawn;
    public DesSpawn _despawn => despawn;
    [SerializeField] protected ShootAbleObjectSO shootAbleObject;
    public ShootAbleObjectSO _shootAbleObject => shootAbleObject;
    [SerializeField] protected ObjectShooting objectShooting;
    public ObjectShooting _objectShooting => objectShooting;
    [SerializeField] protected ObjectMovement objectMovement;
    public ObjectMovement _objectMovement => objectMovement;
    [SerializeField] protected ObjectLookAtTarget objectLookAtTarget;
    public ObjectLookAtTarget _objectLookAtTarget => objectLookAtTarget;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDesqawn();
        this.LoadSO();
        this.LoadObjShooting();
        this.LoadObjMovement();
        this.LoadObjLookAtTarget();
    }

    protected virtual void LoadModel()
    {
        if(this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadObjShooting()
    {
        if(this.objectShooting != null) return;
        this.objectShooting = GetComponentInChildren<ObjectShooting>();
        Debug.Log(transform.name + ": LoadObjShooting", gameObject);
    }
    protected virtual void LoadDesqawn()
    {
        if(this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<DesSpawn>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }

    protected virtual void LoadSO()
    {
        if(this.shootAbleObject != null)return;
        string resPath ="ShootAbleObject/" + this.GetObjectTypeString() + "/" + transform.name;
        this.shootAbleObject = Resources.Load<ShootAbleObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadJunkSO " + resPath, gameObject);
    }

     protected virtual void LoadObjMovement()
    {
        if(this.objectMovement != null) return;
        this.objectMovement = GetComponentInChildren<ObjectMovement>();
        Debug.LogWarning(transform.name + ": LoadObjectMovement", gameObject);
    }

    protected virtual void LoadObjLookAtTarget()
    {   
        if(this.objectLookAtTarget != null) return;
        this.objectLookAtTarget = GetComponentInChildren<ObjectLookAtTarget>();
        Debug.LogWarning(transform.name + ": LoadObjLookAtTarget", gameObject);
    }
    protected abstract string GetObjectTypeString();
}