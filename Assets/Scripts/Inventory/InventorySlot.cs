using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        private InventoryItem _item = null;
        [SerializeField] private InventoryItem emptySlot;
        [SerializeField] private RialtoChannelSO inventoryChannel;
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI text;
        private Texture2D texture;
        public int Count { get; private set; } = 0;

        private int _deduction;

        private void Start()
        {
            _item = emptySlot;
            button.onClick.AddListener(Use);
        }

        private void UpdateText()
        {
            text.text = Count <= 1 ? "" : Count.ToString();
            
            if (Count <= 0)
            {
                image.color = Color.clear;
                image.sprite = null;
                _item = emptySlot;
            }
        }

        public void SetSlot(InventoryItem item)
        {
            texture = item.Texture;
            Count++;
            UpdateText();
            image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f),
                100f);
            image.color = Color.white;
            _item = item;
        }

        public void SetSlot(InventoryItem item, int count)
        {
            texture = item.Texture;
            Count += count;
            UpdateText();
            image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f),
                100f);
            image.color = Color.white;
            _item = item;
        }

        public int ItemType()
        {
            return _item.Type;
        }

        public void DecrementValue(int count)
        {
            Count -= count;
            UpdateText();
            if (Count < 0) throw new ArithmeticException("Count < 0");
        }

        private void Use()
        {
            if (_item.MaxStack > 0)
            {
                _deduction = Count >= _item.MaxStack
                    ? Mathf.Clamp(Count, 0, _item.MaxStack) : 1;
                Count -= _deduction;
            }
            else
            {
                _deduction = 0;
            }
            
            _item.Use(_deduction);
            UpdateText();
        }
    }
}