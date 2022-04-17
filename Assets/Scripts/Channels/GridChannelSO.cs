using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/GridChannel")]
public class GridChannelSO : ScriptableObject
{
    private Action<Transform> OnDestroy;
    public void DestroyAddListener(Action<Transform> action)
    {
        OnDestroy += action;
    }
    public void DestroyRemoveListener(Action<Transform> action)
    {
        OnDestroy -= action;
    }
    public void DestroyBulding(Transform transform)
    {
        OnDestroy?.Invoke(transform);
    }
}
