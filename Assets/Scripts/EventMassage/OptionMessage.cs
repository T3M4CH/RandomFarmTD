using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class OptionMessage : MonoBehaviour
{
    [SerializeField] MessageChannelSO channel;
    [SerializeField] private GameObject messageObject;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Image image;
    private void Start()
    {
        channel.ShowMessageAddListener(ShowMessage);
        channel.CloseMessageAddListener(RemoveMessage);
    }
    private void ShowMessage(Texture2D _texture, string _str)
    {
        messageObject.SetActive(true);
        image.sprite = Sprite.Create(_texture, new Rect(0.0f, 0.0f, _texture.width, _texture.height), Vector2.zero);
        messageText.text = _str;
    }
    private void RemoveMessage()
    {
        messageObject.SetActive(false);
    }
    private void OnDisable()
    {
    }
}
