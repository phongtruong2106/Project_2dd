using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DesSpawnByDistance
{
    public override void DespawnObject()
    {
        ItemDropSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 70f;
    }
}
