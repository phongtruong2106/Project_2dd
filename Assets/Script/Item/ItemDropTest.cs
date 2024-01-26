using UnityEngine;

public class ItemDropTest : NewMonobehavior
{
    public JunkControler junkControler;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.Droping), 2, 0.5f);
    }

    protected virtual void Droping()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkControler._shootAbleObject.dropList, dropPos, dropRot);
    }
}