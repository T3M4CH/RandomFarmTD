using System;
using UnityEngine;
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Healthbar), typeof(Animator))]

public class Enemy : MonoBehaviour, IClickable
{
    [SerializeField] private int health;
    [SerializeField] private Animator animator;
    [HideInInspector] public Movement movement;
    private Renderer meshMaterial;
    public int Health => health;
    private Action OnDamage;
    private Action OnDead;
    private void Start()
    {
        movement = GetComponent<Movement>();
        meshMaterial = transform.GetChild(0).GetComponent<Renderer>();
    }
    public void GetDamage(int damage)
    {
        health -= damage;
        this.OnDamage?.Invoke();
        if (health <= 0)
        {
            animator.Rebind();
            animator.SetTrigger("Dead");
            OnDead?.Invoke();
            gameObject.AddComponent<DisappearScript>();
            Destroy(this);
            return;
        }
    }
    private void OnDestroy()
    {
        Destroy(GetComponent<Movement>());
        Destroy(GetComponent<Healthbar>());
        Destroy(GetComponent<BoxCollider>());
    }

    public void OnHoverEnter()
    {
        GetComponentInChildren<Renderer>().material.SetFloat("_Outline", 0.06f);
    }

    public void OnHoverExit()
    {
        meshMaterial.material.SetFloat("_Outline", 0);
    }

    int IClickable.GetType()
    {
        return 0;
    }

    public void AddListener(Action action)
    {
        OnDamage += action;
    }
    public void RemoveListener(Action action)
    {
        OnDamage -= action;
    }
    
    public void OnDeadListener(Action action)
    {
        OnDead += action;
    }

    public void OnRemoveDeadListener(Action action)
    {
        OnDead -= action;
    }
}
