using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/IntEvent Channel")]
public class IntEventChannelSO : ScriptableObject
{
    private Action<int> OnEventRaise;
    public void AddListener(Action<int> action)
    {
        OnEventRaise += action;
    }
    public void RemoveListener(Action<int> action)
    {
        OnEventRaise -= action;
    }
    public void RaiseEvent(int value)
    {
        OnEventRaise?.Invoke(value);
    }
}
