using UnityEngine;

public class DisappearScript : MonoBehaviour
{
    private float currentTime = 0;
    private bool timeUp => currentTime > 3f;
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (transform.position.y > 4f && timeUp)
        {
            transform.position -= Vector3.up * Time.deltaTime * 5;
        }
        else
        {
            if (timeUp) Destroy(gameObject);
        }
    }
}
