using UnityEngine;

public abstract class ShootAbleObjectControler : NewMonobehavior
{
    [SerializeField] protected Transform model;
    public Transform Model => model;
    [SerializeField] protected DesSpawn despawn;
    public DesSpawn _despawn => despawn;
    [SerializeField] protected ShootAbleObjectSO shootAbleObject;
    public ShootAbleObjectSO _shootAbleObject => shootAbleObject;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDesqawn();
        this.LoadSO();
    }

    protected virtual void LoadModel()
    {
        if(this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
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

    protected abstract string GetObjectTypeString();
}