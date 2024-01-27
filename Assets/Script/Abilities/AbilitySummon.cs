using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner spawner;
    

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }

    protected virtual void Summoning()
    {
        if(!this.isReady) return;
        this.Summon();
    } 

    protected virtual Transform Summon()
    {
        Transform spawnPos = this.abilities._abilityObjectControler._spawnPoint.GetRandom();

        Transform minionPrefab = this.spawner.RandomPrefab();
        Transform minion =  this.spawner.Spawn(minionPrefab,spawnPos.position, spawnPos.rotation);
        minion.gameObject.SetActive(true);
        this.Active();

        return minion;
    }
}