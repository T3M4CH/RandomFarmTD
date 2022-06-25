using Channels;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Inventory/MeepoBonus")]
    public class MeepoItem : UsableItem
    {
        [SerializeField] private VoidChannel meepoBonus;
        public override void Use(int count)
        {
            meepoBonus.Fire();
        }
    }
}
