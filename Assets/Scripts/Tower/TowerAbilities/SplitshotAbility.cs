using UnityEngine;
public class SplitshotAbility : TowerAbility
{
    [SerializeField] private ScanController scanController;
    Enemy[] enemies;
    public override void AbilityAttack()
    {
        Tower tower = GetComponent<Tower>();
        enemies = scanController.FindEnemy(transform, 4);
        if (enemies != null)
        {
            foreach (Enemy x in enemies)
            {
                tower.Attack(x);
            }
        }
    }
}
