using UnityEngine;
using System.Linq;
[CreateAssetMenu(menuName = "ScanController")]
public class ScanController : ScriptableObject
{
    [SerializeField] private LayerMask layerMask;
    public Enemy[] FindEnemy(Transform transform, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        if (colliders.Length == 0)
        {
            return null;
        }
        return colliders.Select(x => x.GetComponent<Enemy>()).ToArray();
    }
    public Enemy[] FindEnemy(Transform transform, float radius, int i)
    {
        Enemy[] enemies = FindEnemy(transform, radius);
        return enemies?.Length < i ? enemies : enemies.Take(i).ToArray();
    }
}
