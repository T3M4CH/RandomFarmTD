using UnityEngine;
using System.Collections.Generic;

public class SpeedAura : MonoBehaviour
{
    [SerializeField] private float percentSpeedBuff;
    [SerializeField] private List<Tower> towers = new List<Tower>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Tower tower) && transform.root != other.transform)
        {
            tower.speedEvent += SpeedBuff;
            towers.Add(tower);
            //enemyMovements.Remove(enemy.movement);
        }
        //other.GetComponent<Tower>().speedEvent += SpeedBuff;
    }
    private void SpeedBuff(ref float speed)
    {
        speed -= percentSpeedBuff;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Tower tower))
        {
            tower.speedEvent -= SpeedBuff;
            towers.Add(tower);
            //enemyMovements.Remove(enemy.movement);
        }
    }
    private void OnDisable()
    {
        foreach(Tower tower in towers)
        {
            tower.speedEvent -= SpeedBuff;
        }
    }
}
