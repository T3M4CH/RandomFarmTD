using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public static class ScanController<T> where T : MonoBehaviour
{
    // ReSharper disable Unity.PerformanceAnalysis
    public static IEnumerable<T> FindObjectsOfType(Vector3 position, float radius)
        => Physics.OverlapSphere(position, radius)
            .Select(x => x.GetComponent<T>())
            .Where(x => x != null);
    public static IEnumerable<T> FindObjectsOfType(Vector3 position, float radius, int count)
        => FindObjectsOfType(position, radius).Take(count);
}
