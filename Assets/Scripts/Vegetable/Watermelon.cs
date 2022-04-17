using UnityEngine;

public class Watermelon : Vegetable, Item
{
    [SerializeField] private InventoryChannelSO inventoryChannel;
    [SerializeField] private Texture2D sprite;
    protected override void ChangeHealth()
    {
        base.ChangeHealth();
        inventoryChannel.GiveItem(this);
    }
    public bool Sellable()
    {
        return true;
    }
    public int Type()
    {
        return 1;
    }

    public Texture2D GetTexture()
    {
        return sprite;
    }
}
