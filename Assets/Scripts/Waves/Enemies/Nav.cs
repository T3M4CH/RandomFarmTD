using UnityEngine;
public class Nav : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;
    public Transform[] positions => _positions;
}
