using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Inventory Channel")]
public class InventoryChannelSO : ScriptableObject
{
    private Action<Item> OnSelectSlot;
    public void SelectAddListener(Action<Item> action)
    {
        OnSelectSlot += action;
    }
    public void SelectRemoveListener(Action<Item> action)
    {
        OnSelectSlot -= action;
    }
    public void GiveItem(Item item)
    {
        OnSelectSlot?.Invoke(item);
    }
}
