
using UnityEngine;

public class EnemySpawner : Spawner
{
     protected static EnemySpawner instance;
    public static EnemySpawner _instance => instance;

    protected override void Awake() 
    {
        base.Awake();
        if(EnemySpawner.instance != null) Debug.LogError("Only one EnemySpawner allow to exist");
        EnemySpawner.instance = this;
    }

}
