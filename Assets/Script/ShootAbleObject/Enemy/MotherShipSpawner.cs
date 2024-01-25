using UnityEngine;

public class MotherShipSpawner : Spawner
{
    protected static MotherShipSpawner instance;
    public static MotherShipSpawner _instance => instance;

    protected override void Awake() 
    {
        base.Awake();
        if(MotherShipSpawner.instance != null) Debug.LogError("Only one MotherShipSpawner allow to exist");
        MotherShipSpawner.instance = this;
    }

}
