using System.Linq;
using Channels;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryChannelSO inventoryChannel;
        [SerializeField] private VoidChannel onWaveChannel;
        [SerializeField] private EventMessageSO eventMessage;
        [SerializeField] private InventorySlot[] inventorySlots;
        [SerializeField] private InventoryItem seed;
        [SerializeField] private Bubble bubblePrefab;
        [SerializeField] private Transform character;
        private void Start()
        {
            onWaveChannel.Subscribe(() => PutItemInside(seed,2));
            inventoryChannel.SelectAddListener(PutItemInside);
            inventoryChannel.SelectManyAddListener(PutItemInside);
        }
        public InventorySlot FirstOrDefault(int type) =>
            inventorySlots.FirstOrDefault(x => x.ItemType() == type)
            ?? inventorySlots.FirstOrDefault(x => x.ItemType() == 0);
        public InventorySlot FirstOrDefault(int type, int count) =>
            inventorySlots.FirstOrDefault(x => x.ItemType() == type && x.Count >= count);
        private void PutItemInside(InventoryItem item)
        {
            InventorySlot inventorySlot = FirstOrDefault(item.Type);
            inventorySlot?.SetSlot(item);
            if (inventorySlot == null)
            {
                eventMessage.SendMessageEvent(Color.red, "Not enough space");
                Instantiate(bubblePrefab, character.transform.position - Vector3.up, Quaternion.identity).PutInside(item);
            }
        }
        private void PutItemInside(InventoryItem item, int count)
        {
            InventorySlot inventorySlot = FirstOrDefault(item.Type);
            inventorySlot?.SetSlot(item, count);
            if (inventorySlot == null)
            {
                eventMessage.SendMessageEvent(Color.red, "Not enough space");
                Instantiate(bubblePrefab, character.transform.position - Vector3.up, Quaternion.identity).PutInside(item, count);
            }
        }
        public void DecrementValueFromSlot(int itemId, int count)
        {
            InventorySlot inventorySlot = FirstOrDefault(itemId, count);
            inventorySlot?.DecrementValue(count);
            if (inventorySlot == null)
            {
                eventMessage.SendMessageEvent(Color.red, "No required resource");
            }
        }
        private void OnDestroy()
        {
            inventoryChannel.SelectRemoveListener(PutItemInside);
        }
    }
}
