using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptAbleObject/Item")]
public class ItemSO : ScriptableObject
{
   public ItemCode itemCode = ItemCode.NoItem;
   public string itemName = "Item";
}
