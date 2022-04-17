using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/AudioChannel")]
public class AudioChannelSO : ScriptableObject
{
    private Action<AudioClip> OnEvent;
    public void AddListener(Action<AudioClip> action)
    {
        OnEvent += action;
    }
    public void RemoveListener(Action<AudioClip> action)
    {
        OnEvent -= action;
    }
    public void PlayClip(AudioClip clip)
    {
        OnEvent?.Invoke(clip);
    }
}
