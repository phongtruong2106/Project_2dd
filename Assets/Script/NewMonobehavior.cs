using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMonobehavior : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }
    protected virtual void Start()
    {
        //for override
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        //for override
    }
}
