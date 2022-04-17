using UnityEngine;

public class AudioSnap : MonoBehaviour
{
    [SerializeField] AudioChannelSO audioChannel;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioChannel.AddListener(PlayClip);
    }
    private void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    
}
