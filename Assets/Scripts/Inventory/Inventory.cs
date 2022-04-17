using UnityEngine;
using System.Linq;
public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryChannelSO inventoryChannel;
    [SerializeField] private EventMessageSO eventMessage;
    [SerializeField] private InventorySlot[] inventorySlots;
    [SerializeField] private Bubble bubblePrefab;
    [SerializeField] private Transform character;
    private void Start()
    {
        inventoryChannel.SelectAddListener(SelectSlot);
    }
    private void SelectSlot(Item item)
    {
        InventorySlot inventorySlot = inventorySlots.FirstOrDefault(x => x.ItemType() == item.Type()) ?? inventorySlots.FirstOrDefault(x => x.ItemType() == 0);
        inventorySlot?.SetSlot(item);
        if(inventorySlot == null)
        {
            eventMessage.OpenMessageEvent(Color.red, "Not enough space");
            Instantiate(bubblePrefab,character.transform.position - Vector3.up, Quaternion.identity).PutInside(item);
        }
    }
    private void OnDisable()
    {
        inventoryChannel.SelectRemoveListener(SelectSlot);
    }
}
