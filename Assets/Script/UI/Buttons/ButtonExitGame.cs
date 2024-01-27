using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExitGame : BaseButton
{
    protected override void OnClick()
    {
        Debug.Log("OnCLick Button Exits");
        Application.Quit();
    }
}