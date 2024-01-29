using UnityEngine;

public class PlayerControler : NewMonobehavior
{
    private static PlayerControler instance;
    public static PlayerControler Instance => instance;
    [SerializeField] protected ShipControler currentShip;
    public ShipControler CurrentShip => currentShip;
    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;

    protected override void Awake()
    {
        base.Awake();
        if(PlayerControler.instance != null) Debug.LogError("Only 1 GameControler allow to ");
        PlayerControler.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup()
    {
        if(this.playerPickup != null) return;
        this.playerPickup = transform.GetComponent<PlayerPickup>();
        Debug.Log(transform.name + ": LoadPlayerPickup", gameObject);

    }
    
}   