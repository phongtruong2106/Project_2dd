using UnityEngine;

public class ButtonOpenInventory : BaseButton
{
    protected override void OnClick()
    {
        UIInventory._instance.Toggel();
    }
}