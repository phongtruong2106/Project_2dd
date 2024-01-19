using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
     //[Header("Item Drop")]
    // [SerializeField] protected int maxlevel = 9;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 5);

    }

    protected virtual void Test()
    {
        this.DropItemIndex(0);
    }

    protected virtual void DropItemIndex(int itemIndex)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        Debug.Log(itemInventory.itemProfile.itemCode);
        Debug.Log(itemInventory.upgradeLevel);
        
        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, transform.rotation);
        this.inventory.Items.Remove(itemInventory);
    }
}