using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Item item = null;
    [SerializeField] private EmptySlot emptySlot;
    [SerializeField] private RialtoChannelSO inventoryChannel;
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;
    private Texture2D texture;
    private int count = 0;
    private void Start()
    {
        item = emptySlot;
        button.onClick.AddListener(() =>
        {
            if (item.Sellable())
            {
                SellItem();
            }
        });
    }
    private void UpdateText()
    {
        text.text = count <= 1 ? "" : count.ToString();
    }
    public void SetSlot(Item _item)
    {
        texture = _item.GetTexture();
        count++;
        UpdateText();
        image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f),100f);
        image.color = Color.white;
        item = _item;
    }
    public int ItemType()
    {
        if (item != null)
        {
            return item.Type();
        }
        return 0;
    }
    private void SellItem()
    {
        if (item != null)
        {
            inventoryChannel.Sell(Mathf.Clamp(count, 0, 5), item.Type());
            count -= Mathf.Clamp(count, 0, 5);
            UpdateText();
            if(count == 0)
            {
                image.color = Color.clear;
                image.sprite = null;
                item = emptySlot;
            }
        }
    }
}
