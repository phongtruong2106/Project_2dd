using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : AbilityObjectControler
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
