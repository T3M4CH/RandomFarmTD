using UnityEngine;

public class TowerCreator : MonoBehaviour
{
    [SerializeField] GridBuilding gridBuilding;
    public void CreateTower(Building gameObject)
    {
        gridBuilding.BuildNewTower(Instantiate(gameObject).GetComponent<Building>());
    }
}
