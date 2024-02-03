using UnityEngine;

public class Pressable : NewMonobehavior
{
    public virtual void Pressed()
    {
        Debug.Log("Pressed: " + transform.parent.parent.name);
    }
}