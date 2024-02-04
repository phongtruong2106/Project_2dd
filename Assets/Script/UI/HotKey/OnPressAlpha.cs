using UnityEngine;

public class OnPressAlpha : UIHotKeyAbstract
{

    private const int numberKeyBoardAlpha = 7;
    private void Update()
    {
        this.CheckAlphaIsPress();
    }

    protected virtual void CheckAlphaIsPress()
    {
        for(int alpha = 1; alpha <= numberKeyBoardAlpha; alpha++)
        {
            if(InputHotKeyManager.Instance.IsAlphaPressed(alpha))
            {
                Press(alpha);
            }
        }
    }

    protected virtual void Press(int alpha)
    {
        //Debug.Log("Press: "  + alpha);
        ItemSlot itemSlot = this.hotKeyController.itemSlots[alpha - 1];
        Pressable pressable = itemSlot.GetComponentInChildren<Pressable>();
        if(pressable == null) return;
        pressable.Pressed();
    }
}