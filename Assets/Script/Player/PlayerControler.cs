using UnityEngine;

public class PlayerControler : NewMonobehavior
{
    private static PlayerControler instance;
    public static PlayerControler Instance => instance;
    [SerializeField] protected ShipControler currentShip;
    public ShipControler CurrentShip => currentShip;
    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;

    [SerializeField] protected PlayerAbility playerAbility;
    public PlayerAbility _playerAbility => playerAbility;

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
        this.LoadPLayerAbility();
    }

    protected virtual void LoadPlayerPickup()
    {
        if(this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + ": LoadPlayerPickup", gameObject);

    }

    protected virtual void LoadPLayerAbility()
    {
        if(this.playerAbility != null) return;
        this.playerAbility = transform.GetComponentInChildren<PlayerAbility>();
        Debug.Log(transform.name + ": LoadPLayerAbility", gameObject);
    }
    
}   