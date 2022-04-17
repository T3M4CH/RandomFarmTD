using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/IntTransformEvent Channel")]
public class TowerManagerChannelSO : ScriptableObject
{
    private Action<Transform,int> OnEventRaise;
    public void AddListener(Action<Transform,int> action)
    {
        OnEventRaise += action;
    }
    public void RemoveListener(Action<Transform, int> action)
    {
        OnEventRaise -= action;
    }
    public void RaiseEvent(Transform transform,int value)
    {
        OnEventRaise?.Invoke(transform,value);
    }
}
