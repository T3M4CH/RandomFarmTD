using System;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/ComplicatedChannel")]
public class IntComplicatedChannel : ScriptableObject
{
    private int[] _compareNum;
    private Action OnRequest;
    private Action<bool,Transform> OnRespond;
    #region RequestRegion
    public void AddRequestListener(Action action)
    {
        OnRequest += action;
    }
    public void RequestRaise(params int[] requiredInt)
    {
        OnRequest?.Invoke();
        _compareNum = requiredInt;
    }
    #endregion
    #region RespondRegion
    public void RespondRaise(int value, Transform _transform)
    {
        OnRespond?.Invoke(_compareNum.Contains(value), _transform);
    }
    public void AddRespondListener(Action<bool,Transform> action)
    {
        OnRespond += action;
    }
    public void RemoveRespondListener(Action<bool,Transform> action)
    {
        OnRespond -= action;
        _compareNum = default;
    }
    #endregion
}