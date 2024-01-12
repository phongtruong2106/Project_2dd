using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance {get => instance;}
    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos{get => mouseWorldPos;}
    [SerializeField] protected float onFiring;
    public float OnFiring{get => onFiring;}



    private void Awake() 
    {
        if(InputManager.instance != null) Debug.LogError("Only one InputManager allow to exist");
        InputManager.instance = this;
    }

    private void Update() {
        this.GetMouseDown();
    }

    private void FixedUpdate() {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
