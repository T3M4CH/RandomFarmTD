using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/EmptySlot")]
public class EmptySlot : ScriptableObject, Item
{
    public Texture2D GetTexture()
    {
        return null;
    }
    public bool Sellable()
    {
        return false;
    }
    public int Type()
    {
        return 0;
    }
}
