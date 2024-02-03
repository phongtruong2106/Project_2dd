using UnityEngine;

public class UIHotKeyController : NewMonobehavior
{
    private static UIHotKeyController instance;
    public static UIHotKeyController _instance {get => instance;}

    protected override void Awake()
    {
        if(UIHotKeyController.instance != null) Debug.LogError("Only one UIHotKeyController allow to exist");
        UIHotKeyController.instance = this;
    }
}