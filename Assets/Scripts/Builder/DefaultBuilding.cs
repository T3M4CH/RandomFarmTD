using UnityEngine;

public class DefaultBuilding : Building
{
    [SerializeField] private TowerManagerChannelSO towerManager;
    [SerializeField] private int level;
    private void Start()
    {
        towerManager.RaiseEvent(transform,level);
    }
}
