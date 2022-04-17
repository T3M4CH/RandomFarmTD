using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/VoidEvent Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    private Action voidEvent;
    public void StartNewWave()
    {
        voidEvent?.Invoke();
    }
    public void VoidEventAddListener(Action action)
    {
        voidEvent += action;
    }
    public void VoidEventRemoveListener(Action action)
    {
        voidEvent -= action;
    }
}