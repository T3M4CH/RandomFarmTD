using UnityEditor;
using UnityEngine;
using System.Linq;
public class Tower : Building, IClickable
{
    [SerializeField] private Transform TowerModel;
    [SerializeField] private Projectile _projectile;
    [SerializeField] private ScanController scanControll;
    [SerializeField] private TowerAbility _ability;
    [Space(2)][Header("Tower Info")]
    [SerializeField] private string _name;
    [SerializeField] private int _lvl;
    [SerializeField] private int _damage;
    [SerializeField] private float delay;
    private float m_delay;
    public delegate void SpeedBuff(ref float speed);
    public event SpeedBuff speedEvent;
    private Enemy _enemy;
    private Transform targetPosition => _enemy.transform;

    public int Level => _lvl;
    public int Damage => _damage;
    public string Name => _name;
    private float currentTime;
    private float nextTime;
    private void Start()
    {
        TowerModel = transform.GetChild(0);
        currentTime = Time.time;
        nextTime = currentTime;
    }
    private void FixedUpdate()
    {
        currentTime = Time.time;
        if (currentTime > nextTime)
        {
            if (_enemy != null)
            {
                TowerModel.LookAt(targetPosition);
                if (Vector3.Magnitude(transform.position - targetPosition.position) < 5)
                {
                    _ability?.AbilityAttack();
                    Attack(targetPosition.GetComponent<Enemy>());
                }
                else
                {
                    Attack();
                }
            }
            else
            {
                Attack();
            }
        }
    }
    public void Attack()
    {
        _enemy = scanControll.FindEnemy(transform,5)?.First();
        if (_enemy != null)
        {
            _enemy.GetDamage(Damage);
            _ability?.AbilityAttack();
            SpawnProjectile(targetPosition);
            ResetDelay();
        }
        else
        {
            TowerModel.rotation = Quaternion.Euler(TowerModel.forward);
        }
    }
    public void SpawnProjectile(Transform _transform)
    {
        Projectile projectile = Instantiate(_projectile, transform.position, Quaternion.identity);
        projectile.SetTarget(_transform);
    }
    public void Attack(Enemy enemy)
    {
        if ((transform.position - enemy.transform.position).magnitude > 5) return;
        this._enemy = enemy;
        ResetDelay();
        SpawnProjectile(targetPosition);
        enemy?.GetDamage(Damage);
    }
    private void ResetDelay()
    {
        m_delay = delay;
        speedEvent?.Invoke(ref m_delay);
        nextTime = currentTime + m_delay;
    }
    int IClickable.GetType()
    {
        return 1;
    }
}