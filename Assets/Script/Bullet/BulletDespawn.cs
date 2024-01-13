using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DesSpawnByDistance
{
    protected override void DespawnObject()
    { 
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
