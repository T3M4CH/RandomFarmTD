using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Rialto Channel")]
public class RialtoChannelSO : ScriptableObject
{
    private Action<int, int> OnSell;
    public void AddListener(Action<int,int> action)
    {
        OnSell += action;
    }
    public void RemoveListener(Action<int,int> action)
    {
        OnSell -= action;
    }
    /// <summary>
    /// Sell Items in Slot
    /// </summary>
    /// <param name="count">1-5</param>
    /// <param name="type">1 watermelon, 2 pumpkin, 3 cabbage</param>
    public void Sell(int count, int type)
    {
        OnSell?.Invoke(count, type);
    }
}
