using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Inventory/BossItem")]
    public class BossItem : InventoryItem
    {
        [SerializeField] private EnemyChannel enemyChannel;
        [SerializeField] private Enemy enemy;
        public override void Use(int count)
        {
            enemyChannel.InvokeEnemy(enemy);
        }
    }
}
