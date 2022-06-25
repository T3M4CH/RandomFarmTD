using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Inventory/SellableItem")]
    public class SellableItem : InventoryItem
    {
        [SerializeField] private RialtoChannelSO rialto;
        
        public override void Use(int count)
        {
            rialto.Sell(count >= 5 ? Mathf.Clamp(count, 0, 5) : 1, Type);
        }
    }
}
