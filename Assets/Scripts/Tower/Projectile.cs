using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform targetTransform;
    private void Update()
    {
        if(targetTransform != null)
        {
            transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * speed);
            if ((targetTransform.position - transform.position).magnitude < 0.8f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetTarget(Transform transform)
    {
        targetTransform = transform;
    }
}
