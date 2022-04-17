using TMPro;
using UnityEngine;
using DG.Tweening;
public class EventMessage : MonoBehaviour
{
    [SerializeField] private EventMessageSO eventMessageChannel;
    [SerializeField] private Transform message;
    [SerializeField] private TextMeshProUGUI text;
    private void Start()
    {
        eventMessageChannel.ShowMessageAddListener(CreateMessage);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            CreateMessage(Color.yellow, "Winner every season!");
        }
    }
    private void CreateMessage(Color _color, string _string)
    {
        TextMeshProUGUI uGUI = Instantiate(text, transform);
        uGUI.transform.DOMoveY(Screen.height / 2, 2).OnComplete(() => Destroy(uGUI.gameObject));
        uGUI.transform.position = message.position;
        uGUI.color = _color;
        uGUI.text = _string;
        uGUI.DOFade(0, 1.5f);
    }
}
