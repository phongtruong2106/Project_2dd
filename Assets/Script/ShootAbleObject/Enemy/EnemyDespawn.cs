using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn: DesSpawnByDistance
{
    public override void DespawnObject()
    {
        EnemySpawner._instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 25f;
    }
}
