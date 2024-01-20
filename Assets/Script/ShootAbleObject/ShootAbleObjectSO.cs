using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShootAbleObject", menuName = "ScriptAbleObject/ShootAbleObject")]
public class ShootAbleObjectSO : ScriptableObject
{
    public string objName = "ShootAble Object";
    public ObjectType objType;
    public int hpMax = 2;
    public List<DropRate> dropList;
}
