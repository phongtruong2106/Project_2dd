using UnityEngine;

public class Abilities : NewMonobehavior
{
    [Header("Abilities")]
    [SerializeField] protected AbilityObjectControler abilityObjectControler;
    public AbilityObjectControler _abilityObjectControler => abilityObjectControler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityObjectControler();
    }

    protected virtual void LoadAbilityObjectControler()
    {
        if(this.abilityObjectControler != null) return;
        this.abilityObjectControler = transform.parent.GetComponent<AbilityObjectControler>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }
}