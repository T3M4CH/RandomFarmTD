using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/MessageEvent Channel")]
public class MessageChannelSO : ScriptableObject
{
    private Action<Texture2D, string> OnShowMessage;
    private Action OnCloseMessage;
    public void ShowMessageAddListener(Action<Texture2D, string> action)
    {
        OnShowMessage += action;
    }
    public void RemoveListener(Action<Texture2D, string> action)
    {
        OnShowMessage -= action;
    }
    public void OpenMessageEvent(Texture2D texture, string str)
    {
        OnShowMessage?.Invoke(texture, str);
    }
    public void CloseMessageAddListener(Action action)
    {
        OnCloseMessage += action;
    }
    public void CloseMessageEvent()
    {
        OnCloseMessage?.Invoke();
    }
}
