using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputHotKeyManager : MonoBehaviour
{
    protected static InputHotKeyManager instance;
    public static InputHotKeyManager Instance {get => instance;}
    
    private bool[] isAlphaPressed = new bool[7];

    private void Awake() 
    {
        if(InputHotKeyManager.instance != null) Debug.LogError("Only one InputHotKeyManager allow to exist");
        InputHotKeyManager.instance = this;
    }

    protected void Update()
    {
        this.GetHostKeyPress();
    }

    protected virtual void GetHostKeyPress()
    {
        for(int alpha = 1; alpha <= 7; alpha++)
        {
            isAlphaPressed[alpha - 1] = Input.GetKeyDown(KeyCode.Alpha0 + alpha);
        }
    }
    public bool IsAlphaPressed(int alpha)
    {
        if(alpha < 1 || alpha > 7) return false;
        return isAlphaPressed[alpha - 1];
    }
}
