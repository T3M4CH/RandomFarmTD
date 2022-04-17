using UnityEngine;
[CreateAssetMenu(menuName = "Other/Array")]
public class SerializeArraySO : ScriptableObject
{
    [SerializeField] private GameObject[] _array;
    public GameObject[] Objects => _array;
}
