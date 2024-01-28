using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarSpawner : Spawner
{
    protected static HPBarSpawner instance;
    public static HPBarSpawner _instance => instance;

    public static string HPBar = "HPBar";
    protected override void Awake() 
    {
        base.Awake();
        if(HPBarSpawner.instance != null) Debug.LogError("Only one HPBarSpawner allow to exist");
        HPBarSpawner.instance = this;
        
    }


}
