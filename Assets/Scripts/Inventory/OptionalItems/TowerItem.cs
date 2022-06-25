using Channels;
using UnityEngine;

namespace Inventory.OptionalItems
{
    [CreateAssetMenu(menuName = "Inventory/TowerItem")]
    public class TowerItem : UsableItem
    {
        [SerializeField] private VoidChannel buildChannel;
            
        public override void Use(int count)
        {
            buildChannel.Fire();
        }
    }
}
