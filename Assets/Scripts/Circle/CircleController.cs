using UnityEngine;
using TMPro;

public class CircleController : MonoBehaviour
{
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject buttonsSecond;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GridBuilding grid;
    public CameraController CameraController => cameraController;
    public GridBuilding Grid => grid;
    [HideInInspector]
    public GameObject followedGameObject;
    [SerializeField] private CircleButtons circleButtons;
    private IClickable click;

    private void Start()
    {
        circleButtons.OnSoldAddListener(ClearCircle);
        circleButtons.OnMergeAddListener(ClearCircle);
        circleButtons.OnMoveAddListener(() =>
        {
            cameraController.ChangeAccessibly(false);
            grid.AddListener(() => cameraController.ChangeAccessibly(true));
        });
        circleButtons.OnSwapAddListener(ClearCircle);
        circleButtons.OnRerollAddListener(ClearCircle);
        circleButtons.OnAttackAddListener(ClearCircle);
    }
    public void MakeCircle(GameObject gameObject, bool drawCircle)
    {
        if (followedGameObject != null) RemoveListeners(click.GetType());

        followedGameObject = gameObject;
        click = followedGameObject.GetComponent<IClickable>();
        ClearCircle();
        if (drawCircle)
        {
            InitCircle(click.GetType());
        }
    }
    private void InitCircle(int type)
    {
        circle.SetActive(true);
        switch (type)
        {
            case 0:
                EnemyCircle();
                break;
            case 1:
                TowerCircle();
                break;
            case 2:
                VegetableCircle();
                break;
            default:
                throw new UnityException("CircleController Exception");
        }
    }
    private void TowerCircle()
    {
        buttons.SetActive(true);
    }
    private void EnemyCircle()
    {
        text.gameObject.SetActive(true);
        text.text = followedGameObject.GetComponent<Enemy>().Health.ToString();
        followedGameObject.GetComponent<Enemy>().OnDeadListener(OnEnemyRemoveListener);
        followedGameObject.GetComponent<Enemy>().AddListener(EnemyUpdateUI);
    }
    private void EnemyUpdateUI()
    {
        if ((bool)(followedGameObject?.TryGetComponent(out Enemy enemy)))
        {
            text.text = followedGameObject.GetComponent<Enemy>().Health >= 0 ? followedGameObject.GetComponent<Enemy>().Health.ToString() : "0";
        }
    }
    private void OnEnemyRemoveListener()
    {
        circle.SetActive(false);
        followedGameObject.GetComponent<Enemy>().RemoveListener(EnemyUpdateUI);
        followedGameObject.GetComponent<Enemy>().OnRemoveDeadListener(OnEnemyRemoveListener);
    }
    private void VegetableCircle()
    {
        text.gameObject.SetActive(true);
        text.text = followedGameObject.GetComponent<Vegetable>().Health.ToString();
        followedGameObject.GetComponent<Vegetable>().OnGoneAddListener(VegetableRemoveListener);
        followedGameObject.GetComponent<Vegetable>().OnChangeHealthAddListener(VegetableUpdateUI);
    }
    private void VegetableUpdateUI(int health)
    {
        text.text = health.ToString();
    }
    private void VegetableRemoveListener()
    {
        followedGameObject.GetComponent<Vegetable>()?.OnGoneRemoveListener(VegetableRemoveListener);
        followedGameObject.GetComponent<Vegetable>()?.OnChangeHealthRemoveListener(VegetableUpdateUI);
        circle.SetActive(false);
    }
    private void RemoveListeners(int type)
    {
        if (followedGameObject == null) return;
        switch (type)
        {
            case 0:
                followedGameObject.GetComponent<Enemy>()?.RemoveListener(EnemyUpdateUI);
                followedGameObject.GetComponent<Enemy>()?.OnRemoveDeadListener(OnEnemyRemoveListener);
                break;
            case 1:
                TowerCircle();
                break;
            case 2:
                followedGameObject.GetComponent<Vegetable>()?.OnChangeHealthRemoveListener(VegetableUpdateUI);
                followedGameObject.GetComponent<Vegetable>()?.OnGoneRemoveListener(VegetableRemoveListener);
                break;
            default:
                throw new UnityException("CircleController Exception");
        }
    }
    public void ClearCircle()
    {
        if (followedGameObject != null)
        {
            RemoveListeners(click.GetType());
        }
        circle.SetActive(false);
        text.gameObject.SetActive(false);
        buttons.SetActive(false);
        buttonsSecond.SetActive(false);
    }
}
