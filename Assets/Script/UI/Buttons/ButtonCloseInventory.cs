using UnityEngine;

public class ButtonCloseInventory : BaseButton
{
    protected override void OnClick()
    {
        UIInventory._instance.Close();
    }
}