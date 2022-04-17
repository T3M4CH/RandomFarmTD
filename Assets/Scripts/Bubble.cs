using DG.Tweening;
using UnityEngine;
public class Bubble : MonoBehaviour, IClickable
{
    [SerializeField] private Transform childTransform;
    [SerializeField] private AudioChannelSO audioChannel;
    [SerializeField] private InventoryChannelSO inventoryChannel;
    [SerializeField] private AudioClip clip;
    [SerializeField] private Texture2D _texture;
    private int maxSize;
    private Item item;
    public void OnHoverEnter()
    {
        audioChannel.PlayClip(clip);
        inventoryChannel.GiveItem(item);
        Destroy(gameObject);
    }
    public void OnHoverExit()
    {
        Debug.Log("RasFocus");
    }
    int IClickable.GetType()
    {
        return 3;
    }
    private void Start()
    {
        transform.DOScale(2, 2).SetEase(Ease.InBounce);
        transform.DOMoveY(8, 2).SetEase(Ease.InFlash).OnComplete(() =>
        {
            transform.DOMoveY(7.8f, 2).SetLoops(-1, LoopType.Yoyo);
        });
    }
    public void PutInside(Item item)
    {
        this.item = item;
        _texture = item.GetTexture();
        maxSize = Mathf.Max(_texture.width, _texture.height);
        childTransform.localScale = new Vector2(1 / (maxSize / 76f), 1 / (maxSize / 76f));
        childTransform.GetComponent<SpriteRenderer>().sprite = Sprite.Create(_texture, new Rect(0.0f, 0.0f, _texture.width, _texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
    private void OnDisable()
    {
        DOTween.Kill(transform);
    }
}
