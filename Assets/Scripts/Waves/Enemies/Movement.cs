using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float m_speed;
    private Nav nav;
    private Vector3 direction;
    private int currentPositionId = 0;
    public delegate void MovementDebuff(ref float speed);
    public event MovementDebuff movementEvent;
    void Start()
    {
        nav = FindObjectOfType<Nav>();
    }
    private void FixedUpdate()
    {
        m_speed = speed;
        movementEvent?.Invoke(ref m_speed);
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, nav.positions[currentPositionId].position, Time.fixedDeltaTime * m_speed);
        direction = nav.positions[currentPositionId].position - transform.position;
        if(direction != Vector3.zero)
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), speed * Time.fixedDeltaTime * 100);
        if (Vector3.Distance(transform.position, nav.positions[currentPositionId].position) < 0.05f)
        {
            if (currentPositionId == nav.positions.Length - 1)
            {
                FinishCreep();
                return;
            }
            currentPositionId += 1;
        }
    }
    private void FinishCreep()
    {
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        movementEvent = null;
    }
}
