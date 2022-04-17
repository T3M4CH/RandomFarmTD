using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/VectorEvent Channel")]
public class VectorEventChannelSO : ScriptableObject
{
    private Action<bool> OnReach;
    private Action<Vector3> OnAction;
    public void AddListener(Action<Vector3> action)
    {
        OnAction += action;
    }
    public void RemoveListener(Action<Vector3> action)
    {
        OnAction -= action;
    }
    public void CallEvent(Vector3 vector)
    {
        OnAction?.Invoke(vector);
    }
    public void OnReachAddListener(Action<bool> action)
    {
        OnReach += action;
    }
    public void OnReachRemoveListener(Action<bool> action)
    {
        OnReach -= action;
    }
    public void ReachEvent(bool result)
    {
        OnReach?.Invoke(result);
    }
}
