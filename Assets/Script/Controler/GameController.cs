using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : NewMonobehavior
{
    private static GameController instance;
    public static GameController Instance{get => instance;}

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera{get => mainCamera;}

    protected override void Awake()
    {
        base.Awake();
        if(GameController.instance != null) Debug.LogError("Only 1 GameManager allow to ");
        GameController.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if(this.mainCamera != null) return;
        this.mainCamera = GameController.FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }
}
