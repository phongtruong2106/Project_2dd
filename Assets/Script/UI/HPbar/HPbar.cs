using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar: NewMonobehavior
{
    [Header("HPbar")]
    [SerializeField] protected ShootAbleObjectControler shootAbleObjectControler;
    [SerializeField] protected SliderHP sliderHP; 

    protected virtual void FixedUpdate()
    {
        this.ShowHP();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
    }

    protected virtual void LoadSliderHP()
    {
        if(this.sliderHP != null) return;
        this.sliderHP = transform.GetComponentInChildren<SliderHP>();
        Debug.LogWarning(transform.name + ": LoadSliderHP", gameObject);
    }

    protected virtual void ShowHP()
    {
        if(this.shootAbleObjectControler == null) return;
        
       float hp = this.shootAbleObjectControler._damageReceiver._hp;
       float maxHP = this.shootAbleObjectControler._damageReceiver._maxHp;

       this.sliderHP.SetCurrentHP(hp);
       this.sliderHP.SetMaxHP(maxHP);
    }

    public virtual void SetObjectControler(ShootAbleObjectControler shootAbleObjectControler)
    {
        this.shootAbleObjectControler = shootAbleObjectControler;
    }
}