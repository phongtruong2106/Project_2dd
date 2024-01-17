using UnityEngine;

public abstract class PlayerAbstract : NewMonobehavior
{
    [Header("Player Abstract")]
    [SerializeField] protected PlayerControler playerControler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerControler();
    }

    protected virtual void LoadPlayerControler()
    {
        if(this.playerControler != null) return;
        this.playerControler = transform.GetComponentInParent<PlayerControler>();
        Debug.Log(transform.name + ": LoadPlayerControler", gameObject);
    }
}