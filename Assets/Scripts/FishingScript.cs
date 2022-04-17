using UnityEngine.EventSystems;
using UnityEngine;

public class FishingScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform handleTransform;
    [SerializeField] private float radius = 300;
    [SerializeField] private float offset = 50;
    [SerializeField] private float degree = 0;
    private RectTransform rect;
    private Vector2 tempVector;
    private float sum;
    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        tempVector += new Vector2(eventData.delta.x, eventData.delta.y);
        sum = Mathf.Pow(tempVector.x, 2) + Mathf.Pow(tempVector.y, 2);
        if (sum >= Mathf.Pow(radius - offset, 2))
        {
            rect.anchoredPosition += new Vector2(eventData.delta.x, eventData.delta.y);
            rect.anchoredPosition = new Vector2(Mathf.Clamp(rect.anchoredPosition.x, -300, 300), Mathf.Clamp(rect.anchoredPosition.y, -300, 300));
            handleTransform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(rect.anchoredPosition.y, rect.anchoredPosition.x) * Mathf.Rad2Deg));
        }
        tempVector = rect.anchoredPosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        rect.anchoredPosition = new Vector2(Mathf.Cos(handleTransform.rotation.eulerAngles.z * Mathf.Deg2Rad),
            Mathf.Sin(handleTransform.rotation.eulerAngles.z * Mathf.Deg2Rad)) * 225;
    }
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
}