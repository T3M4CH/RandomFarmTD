using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "BubbleCreator")]
    public class BubbleCreator : ScriptableObject
    {
        [SerializeField] private Bubble bubblePrefab;

        public void CreateBubble(InventoryItem item, Vector3 position)
        {
            Instantiate(bubblePrefab, position, Quaternion.identity).PutInside(item);
        }
        public void CreateBubble(InventoryItem item, int count ,Vector3 position)
        {
            Instantiate(bubblePrefab, position, Quaternion.identity).PutInside(item, count);
        }
    }
}
