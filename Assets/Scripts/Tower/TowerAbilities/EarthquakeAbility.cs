using System.Linq;
using System.Collections.Generic;
using UnityEngine;
public class EarthquakeAbility : TowerAbility
{
    [SerializeField] private float delay;
    [SerializeField] private ScanController scanController;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioChannelSO audioChannel;
    [SerializeField] private ParticleSystem echoEffect;
    private float currentTime = 0;
    private float nextTime;
    private void Start()
    {
        echoEffect = Instantiate(echoEffect, transform);
        echoEffect.transform.position = transform.position + new Vector3(.5f, 0, .5f);
    }
    public override void AbilityAttack()
    {
        currentTime = Time.time;
        if (currentTime > nextTime)
        {
            echoEffect.Play();
            audioChannel.PlayClip(audioClip);
            foreach (Enemy enemy in scanController.FindEnemy(transform, 6) ?? Enumerable.Empty<Enemy>())
            {
                enemy.GetDamage(20);
            }
            nextTime = currentTime + delay;
        }
    }
}
