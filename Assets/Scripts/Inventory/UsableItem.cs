using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class UsableItem : InventoryItem
    {
        public override void Use(int count)
        {
        }
    }
}