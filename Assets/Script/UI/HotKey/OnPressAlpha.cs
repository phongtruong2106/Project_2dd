using UnityEngine;

public class OnPressAlpha : NewMonobehavior
{
    private void Update()
    {
        this.CheckAlphaIsPress();
    }

    protected virtual void CheckAlphaIsPress()
    {
        if(InputHotKeyManager.Instance.isAlpha1) Debug.Log("IsAlpha1");
        if(InputHotKeyManager.Instance.isAlpha2) Debug.Log("IsAlpha2");
        if(InputHotKeyManager.Instance.isAlpha3) Debug.Log("IsAlpha3");
        if(InputHotKeyManager.Instance.isAlpha4) Debug.Log("IsAlpha4");
        if(InputHotKeyManager.Instance.isAlpha5) Debug.Log("IsAlpha5");
        if(InputHotKeyManager.Instance.isAlpha6) Debug.Log("IsAlpha6");
        if(InputHotKeyManager.Instance.isAlpha7) Debug.Log("IsAlpha7");
    }
}