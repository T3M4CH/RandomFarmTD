using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/BoolEvent Channel")]
public class BoolEventChannelSO : ScriptableObject
{
    private Action<bool> boolEvent;
    public void StartBoolEvent(bool state)
    {
        boolEvent?.Invoke(state);
    }
    public void BoolEventAddListener(Action<bool> action)
    {
        boolEvent += action;
    }
    public void BoolEventRemoveListener(Action<bool> action)
    {
        boolEvent -= action;
    }
}