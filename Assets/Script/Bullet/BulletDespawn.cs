using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DesSpawnByDistance
{
    public override void DespawnObject()
    { 
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
