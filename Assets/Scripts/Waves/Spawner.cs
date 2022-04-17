using System.Collections;
using UnityEngine;

namespace WaveMobs
{ 
    public class Spawner : MonoBehaviour
    {
        [SerializeField] WaveManager waveManager;
        private GameObject prefab;

        private void Start()
        {
            //StartCoroutine("SpawnCoroutine",  10);
        }

        private void Update()
        {

        }

        public void Spawn(GameObject prefab)
        {
            Instantiate(prefab, new Vector3(13.5f, 6, 43), Quaternion.identity);
        }
        private IEnumerator SpawnCoroutine(int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                Instantiate(prefab, new Vector3(13.5f, 6, 43), Quaternion.identity);
                yield return new WaitForSeconds(1);
            }
        }

        public void CallCoroutine(int i, GameObject prefab)
        {
            this.prefab = prefab;
            StartCoroutine("SpawnCoroutine", i);
        }
    }
}
