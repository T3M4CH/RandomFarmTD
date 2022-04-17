using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Trader : MonoBehaviour, IClickable
{
    [SerializeField]
    private GameObject shop;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void ChangeAnim(bool condition)
    {
        animator.SetBool("Active", condition);
    }

    public void OnHoverEnter()
    {
        ChangeAnim(true);
        shop.SetActive(true);
    }

    public void OnHoverExit()
    {
        ChangeAnim(false);
        shop.SetActive(false);
    }

    int IClickable.GetType()
    {
        return 3;
    }
}
