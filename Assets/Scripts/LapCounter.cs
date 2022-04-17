using UnityEngine;
public class LapCounter : MonoBehaviour
{
    [SerializeField] private float delta;
    [SerializeField] private float distance = 0;
    [SerializeField] private int lapCount = 0;
    private float rotationZ;
    private void Start()
    {
        rotationZ = transform.rotation.eulerAngles.z;
    }
    private void Update()
    {
        if (transform.eulerAngles.z != rotationZ)
        {
            delta = Mathf.Clamp(transform.rotation.eulerAngles.z - rotationZ, -10, 10);
            distance += delta;
            if(Mathf.Abs(distance) > 360)
            {
                distance = 0;
                lapCount += 1;
            }
        }
        rotationZ = transform.rotation.eulerAngles.z;
    }
}