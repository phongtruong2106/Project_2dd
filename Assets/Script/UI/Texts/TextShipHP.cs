using UnityEngine;

public class TextShipHP : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHP();
    }

    protected virtual void UpdateShipHP()
    {
        
        int hp =  PlayerControler.Instance.CurrentShip._damageReceiver._hp;
        int maxHp = PlayerControler.Instance.CurrentShip._damageReceiver._maxHp;
        this.text.SetText(hp + "/" + maxHp);
    }
}