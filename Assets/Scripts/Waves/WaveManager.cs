using UnityEngine;

namespace WaveMobs
{
    [RequireComponent(typeof(Spawner))]
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] MobsArray;
        [SerializeField] private TimeController timeManager;
        [SerializeField] private VoidEventChannelSO waveChannel;
        private Spawner spawner;
        private void Start()
        {
            waveChannel.VoidEventAddListener(InvokeSpawnWave);
            spawner = GetComponent<Spawner>();
        }

        private void InvokeSpawnWave()
        {
            spawner.CallCoroutine(5, MobsArray[Mathf.Clamp(timeManager.WaveCount - 1,0, MobsArray.Length - 1)]);
        }
    }
}
