using System;
[Serializable]
public class ItemInventory
{   
    public string itemID;
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory()
        {
            itemID = ItemInventory.RandomID(),
            itemProfile = this.itemProfile,
            itemCount = this.itemCount,
            upgradeLevel = this.upgradeLevel
        };
        return item;
    }

    public static String RandomID()
    {
        return RandomStringGenerator.Generate(27);
    }
}