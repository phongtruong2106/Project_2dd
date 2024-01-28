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


    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(newEnemy);

        return newEnemy;
    }

    protected virtual void AddHPBar2Obj(Transform newEnemy)
    {
        ShootAbleObjectControler shootAbleObjectControler = newEnemy.GetComponent<ShootAbleObjectControler>();
        Transform newHPBar = HPBarSpawner._instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HPbar hpbar = newHPBar.GetComponent<HPbar>();
        hpbar.SetObjectControler(shootAbleObjectControler);
        hpbar.SetFollowTarget(newEnemy);
        newHPBar.gameObject.SetActive(true);
    }
}
