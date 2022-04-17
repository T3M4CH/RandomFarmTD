using System.Collections;
using UnityEngine;
using TMPro;

public class WaveCountText : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip defaultWaveClip;
    [SerializeField] private IntEventChannelSO waveChannel;
    private TextMeshProUGUI text;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        text = GetComponent<TextMeshProUGUI>();
        waveChannel.AddListener(StartCoroutine);
    }

    private void StartCoroutine(int i)
    {
        StartCoroutine(nameof(TextCoroutine), $"Wave {i}");
    }
    private IEnumerator TextCoroutine(string _str)
    {
        int i = 0;
        yield return new WaitForSeconds(.05f);
        audioSource.PlayOneShot(defaultWaveClip);
        while (i < _str.Length)
        {
            text.text += _str[i];
            yield return new WaitForSeconds(.15f);
            i += 1;
        }
        yield return new WaitForSeconds(2f);
        text.text = "";
    }
}
