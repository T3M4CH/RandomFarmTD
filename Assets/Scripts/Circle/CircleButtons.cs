using System;
using UnityEngine;
using UnityEngine.UI;

public class CircleButtons : MonoBehaviour
{
    public GameObject followedGameObject => circleController.followedGameObject;
    private Action OnSold;
    private Action OnMerge;
    private Action OnMove;
    private Action OnSwap;
    private Action OnReroll;
    private Action OnAttack;
    [SerializeField] CircleController circleController;
    [SerializeField] Button soldTowerButton;
    [SerializeField] GameObject MoveMenu;
    [SerializeField] GameObject Menu;
    [SerializeField] Tower[] towers;


    public void OpenButtonsMenu(bool state)
    {
        MoveMenu.SetActive(state);
        Menu.SetActive(!state);
    }
    public void MoveTower()
    {
        OnMove?.Invoke();
    }
    public void OnMoveAddListener(Action action)
    {
        OnMove += action;
    }
    public void MergeTowers()
    {
        OnMerge?.Invoke();
    }
    public void OnMergeAddListener(Action action)
    {
        OnMerge += action;
    }
    public void SoldTower()
    {
        OnSold?.Invoke();
    }
    public void OnSoldAddListener(Action action)
    {
        OnSold += action;
    }
    public void SwapTower()
    {
        OnSwap?.Invoke();
    }
    public void OnSwapAddListener(Action action)
    {
        OnSwap += action;
    }
    public void RerollTower()
    {
        OnReroll?.Invoke();
    }
    public void OnRerollAddListener(Action action)
    {
        OnReroll += action;
    }
    public void Attack()
    {
        OnAttack?.Invoke();
    }
    public void OnAttackAddListener(Action action)
    {
        OnAttack += action;
    }
}
