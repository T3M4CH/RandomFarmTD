using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/EventMessagea")]
public class EventMessageSO : ScriptableObject
{
    private Action<Color, string> OnShowMessage;
    public void ShowMessageAddListener(Action<Color, string> action)
    {
        OnShowMessage += action;
    }
    public void RemoveListener(Action<Color, string> action)
    {
        OnShowMessage -= action;
    }
    public void OpenMessageEvent(Color color, string str)
    {
        OnShowMessage?.Invoke(color, str);
    }
}
