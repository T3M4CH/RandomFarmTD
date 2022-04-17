using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class SlowdownAbility : MonoBehaviour
{
    [SerializeField] private float percentSlowdown;
    private List<Movement> enemyMovements = new List<Movement>();
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.movement.movementEvent += SlowdownAura;
            enemyMovements.Add(enemy.movement);
        }
    }
    private void SlowdownAura(ref float speed)
    {
        speed *= 1f - percentSlowdown;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.movement.movementEvent -= SlowdownAura;
            enemyMovements.Remove(enemy.movement);
        }
    }
    private void OnDisable()
    {
        foreach (Movement movement in enemyMovements)
        {
            movement.movementEvent -= SlowdownAura;
        }
    }
}
