using UnityEngine;
using System.Linq;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private TowerManagerChannelSO levelChannel;
    [SerializeField] private IntComplicatedChannel complicatedChannel;
    [SerializeField] private MessageChannelSO message;
    [SerializeField] private SerializeArraySO towerList;
    [SerializeField] private GridBuilding grid;
    [SerializeField] private TouchScript touchScript;
    [SerializeField] private CircleButtons buttons;
    private Tower towerScript => buttons.followedGameObject.GetComponent<Tower>();
    Transform towerTransform => buttons.followedGameObject.transform;
    private Tower tower;
    private void Start()
    {
        buttons.OnSwapAddListener(() =>
        {
            complicatedChannel.RequestRaise(1,2);
            complicatedChannel.AddRespondListener(SwapTowers);
            message.OpenMessageEvent(Resources.Load("Repeat") as Texture2D, "Select tower");
            tower = towerScript;
        });
        buttons.OnMergeAddListener(MergeTowers);
        buttons.OnSoldAddListener(SoldTower);
        buttons.OnMoveAddListener(MoveTower);
        buttons.OnRerollAddListener(RerollTower);
        levelChannel.AddListener(ReplaceTower);
        buttons.OnAttackAddListener(() =>
        {
            complicatedChannel.RequestRaise(0);
            complicatedChannel.AddRespondListener(Attack);
            message.OpenMessageEvent(Resources.Load("Attack") as Texture2D, "Select fiend");
            tower = towerScript;
        });
    }
    private void MoveTower()
    {
        grid.MoveExistTower(towerTransform.GetComponent<Building>());
    }
    private void SoldTower()
    {
        grid.DestroyBuilding(towerTransform);
        Destroy(towerTransform.gameObject);
    }
    private void MergeTowers()
    {
        string name = towerScript.Name;
        Tower[] towers = FindObjectsOfType<Tower>();
        if (towers.Length == 1)
        {
            Debug.Log("Lenght = 1");
            return;
        }
        Tower tower = towers.Where(x => x.Name == name && x != towerScript).FirstOrDefault();
        grid.DestroyBuilding(tower.transform);
        Destroy(tower.gameObject);
        ReplaceTower(tower.Level + 1);
    }
    private void SwapTowers(bool state, Transform _transform)
    {
        if (state)
        {
            Vector3 tmpPosition = tower.transform.position;
            tower.transform.position = _transform.position;
            _transform.position = tmpPosition;
        }
        message.CloseMessageEvent();
        complicatedChannel.RemoveRespondListener(SwapTowers);
    }
    private void RerollTower()
    {
        ReplaceTower(tower.Level);
    }
    private void ReplaceTower(Transform _transform, int _level)
    {
        Tower tower = Instantiate(towerList.Objects[Random.Range(0,5)], _transform.position, Quaternion.identity).GetComponent<Tower>();
        Destroy(_transform.gameObject);
        tower.enabled = true;
        tower.boxCollider.enabled = true;
    }
    private void ReplaceTower(int towerLvl)
    {
        Tower tower = Instantiate(towerList.Objects[Random.Range(0, 5)], towerTransform.position, Quaternion.identity).GetComponent<Tower>();
        Destroy(towerTransform.gameObject);
        tower.enabled = true;
        tower.boxCollider.enabled = true;
    }
    private void Attack(bool _boolean, Transform _transform)
    {
        if (_boolean)
        {
            tower.Attack(_transform.GetComponent<Enemy>());
        }
        message.CloseMessageEvent();
        complicatedChannel.RemoveRespondListener(Attack);
    }
}