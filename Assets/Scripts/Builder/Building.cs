using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public abstract class Building : MonoBehaviour
{
    [HideInInspector] public BoxCollider boxCollider;
    [Header("Primary Components")]
    [SerializeField] private Renderer meshRenderer;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    public void OnHoverEnter()
    {
        meshRenderer.material.SetFloat("_Outline", 0.06f);
    }
    public void OnHoverExit()
    {
        meshRenderer.material.SetFloat("_Outline", 0);
    }
}
