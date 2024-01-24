using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    [Header("Ability Summon")]
    [SerializeField] protected List<Transform> minion;
    [SerializeField] protected int minionLimit = 2;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.ClearDeadMinion();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
    }

    protected virtual void LoadEnemySpawner()
    {
        if(this.spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<EnemySpawner>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawner", gameObject);
    }

    protected override void Summoning()
    {
        if(this.minion.Count >= this.minionLimit) return;
        base.Summoning();
    } 

    protected override Transform Summon()
    {
        Transform minion = base.Summon();
        minion.parent = this.abilities._abilityObjectControler.transform;
        this.minion.Add(minion);
        return minion;
    }

    protected virtual void ClearDeadMinion()
    {
        foreach(Transform minion in this.minion)
        {
            if(minion.gameObject.activeSelf == false)
            {
                this.minion.Remove(minion);
                return;
            }
        }
    }
}