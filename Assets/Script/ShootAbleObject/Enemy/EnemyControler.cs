using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : ShootAbleObjectControler
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
