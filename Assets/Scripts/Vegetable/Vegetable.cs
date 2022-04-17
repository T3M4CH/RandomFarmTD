using System;
using UnityEngine;

public class Vegetable : Building, IClickable
{
    [SerializeField] private GridChannelSO gridChannel;
    [SerializeField] private VoidEventChannelSO waveChannel;
    private int health = 2;
    public int Health => health;
    private Action OnGone;
    private Action<int> OnChangeHealth;
    public void OnGoneAddListener(Action action)
    {
        OnGone += action;
    }
    public void OnGoneRemoveListener(Action action)
    {
        OnGone -= action;
    }
    public void OnChangeHealthAddListener(Action<int> action)
    {
        OnChangeHealth += action;
    }
    public void OnChangeHealthRemoveListener(Action<int> action)
    {
        OnChangeHealth -= action;
    }
    int IClickable.GetType()
    {
        return 2;
    }
    protected virtual void ChangeHealth()
    {
        health -= 1;
        if (health > 0)
        {
            OnChangeHealth?.Invoke(Health);
        }
        else
        {
            OnGone?.Invoke();
            gridChannel.DestroyBulding(transform);
            waveChannel.VoidEventRemoveListener(ChangeHealth);
            gameObject.AddComponent<DisappearScript>();
        }
    }
    private void OnEnable()
    {
        waveChannel.VoidEventAddListener(ChangeHealth);
    }
    private void OnDisable()
    {
        waveChannel.VoidEventRemoveListener(ChangeHealth);
    }
}
