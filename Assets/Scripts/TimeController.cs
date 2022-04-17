using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{
    [Range(1, 4)]
    [SerializeField]
    private float timeMultiplier = 1;
    [SerializeField] private VoidEventChannelSO waveChannel;
    [SerializeField] private IntEventChannelSO intWaveChannel;
    [SerializeField]
    private Slider timeSlider;
    [SerializeField]
    private TextMeshProUGUI timeText;
    private int waveCount = 0;
    public int WaveCount => waveCount;
    public Action UpdateWave;

    private void Start()
    {
        StartCoroutine("Time", 3);
    }
    private IEnumerator Time(int seconds)
    {
        int currentSeconds = 0;
        while (seconds > currentSeconds)
        {
            yield return new WaitForSeconds(1f * timeMultiplier);
            currentSeconds += (int)(1f * timeMultiplier);
            OnChangeTimeValue(currentSeconds, seconds);
        }
        TimerRepeat();
    }

    private void OnChangeTimeValue(float currentValue, float maxValue)
    {
        if(currentValue == 1 && waveCount > 0)
        {
            waveChannel.StartNewWave();
            intWaveChannel.RaiseEvent(waveCount);
        }
        timeText.text = $"{currentValue} / {maxValue} ";
        timeSlider.value = currentValue / maxValue;
    }
    public void UpdateWaveAddListener(Action action)
    {
        UpdateWave += action;
    }
    public void UpdateWaveRemoveListener(Action action)
    {
        UpdateWave -= action;
    }
    private void TimerRepeat()
    {
        StartCoroutine("Time", Mathf.Clamp(5 + waveCount * 2, 10, 15));
        waveCount += 1;
    }
}
