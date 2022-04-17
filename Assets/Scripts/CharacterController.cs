using System;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    [SerializeField] private VectorEventChannelSO vectorEventChannel;
    [SerializeField] private GameObject sparks;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 0;
    private Vector3 towardPosition;
    private bool SleepState = false;
    private bool FarDistance => Vector3.Distance(towardPosition, transform.position) > 1f;

    private void Start()
    {
        vectorEventChannel.AddListener(Move);
        towardPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            CancelMove();
            Fell();
        }
        if (FarDistance)
        {
            Move(towardPosition);
        }
    }
    public void CancelMove()
    {
        towardPosition = transform.position;
    }
    public void Move(Vector3 position)
    {
        if (SleepState)
        {
            animator.SetBool("AFK", false);
            return;
        }
        if (position != towardPosition)
        {
            GameObject sparksInstance = Instantiate(sparks, position, Quaternion.identity);
            Destroy(sparksInstance, .5f);
            transform.LookAt(position);
            towardPosition = position;
            vectorEventChannel?.ReachEvent(false);
            Invoke("Recurse", Time.deltaTime);
        }
        transform.position = Vector3.MoveTowards(transform.position, position, Time.fixedDeltaTime * speed);
        if (!FarDistance)
        {
            vectorEventChannel?.ReachEvent(true);
        }
    }
    private void Recurse()
    {
        Move(towardPosition);
    }
    public void Fell()
    {
        animator.SetBool("AFK", true);
        SleepState = true;
        speed = 0;
    }
    #region AnimationEvent
    public void AwakeCheck()
    {
        vectorEventChannel?.ReachEvent(true);
        SleepState = false;
        speed = 7;
    }
    #endregion
}