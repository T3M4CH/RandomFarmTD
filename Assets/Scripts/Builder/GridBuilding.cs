using UnityEngine;
using System;

public class GridBuilding : MonoBehaviour
{
    private int[,] Grid = new int[38, 38]
    {
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    };
    private Building building;
    private Transform buildingTransform => building.transform;
    [SerializeField] private TextureController texture;
    [SerializeField] private VectorEventChannelSO vectorEventChannel;
    [SerializeField] private GridChannelSO gridChannel;
    [SerializeField] private TouchScript touchScript;
    [SerializeField] private LayerMask layerMask;
    private bool OrderToBuild = false;
    private bool towerExisted = false;
    private Action OnDone;
    private Vector2Int previousPos;

    private void Start()
    {
        gridChannel.DestroyAddListener(DestroyBuilding);
    }
    private void Update()
    {
        if (building == null || OrderToBuild == true) return;
        if (touchScript.enabled) touchScript.enabled = false;
        if (Input.GetMouseButtonDown(0))
        {
            if (CheckCoord(new Vector2Int((int)buildingTransform.position.x, (int)buildingTransform.position.z)))
            {
                vectorEventChannel.CallEvent(new Vector3Int((int)buildingTransform.position.x, 6, (int)buildingTransform.position.z));
                vectorEventChannel.OnReachAddListener(PlaceBuilding);
                OrderToBuild = true;
                touchScript.enabled = true;
            }
            else
            {
                DestroyTower();
            }
            return;
        }
        if (!OrderToBuild) GridPlacement();
    }
    private void GridPlacement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
        {
            Vector3Int newPos = new Vector3Int(Mathf.Clamp((int)raycastHit.point.x, 8, 42), 6, Mathf.Clamp((int)raycastHit.point.z, 13, 47));
            if (buildingTransform.position != newPos)
            {
                texture.SetGrid(new Vector2Int(newPos.x, newPos.z));
            }
            buildingTransform.position = newPos;
        }
    }
    public bool CheckCoord(Vector2Int center)
    {
        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                if (Grid[48 - center.y + y, center.x - 7 + x] == 0) return false;
            }
        }
        return true;
    }
    public void SetCoord(Vector2Int center, int value)
    {
        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                Grid[48 - center.y + y, center.x - 7 + x] = value;
            }
        }
    }
    private void PlaceBuilding(bool permit)
    {
        if (permit)
        {
            building.enabled = true;
            TextureSetActive(false);
            if (building != null)
            SetCoord(new Vector2Int((int)buildingTransform.position.x, (int)buildingTransform.position.z), 0);
            OnDone?.Invoke();
        }
        else
        {
            DestroyTower();
            TextureSetActive(false);
        }
        building = null;
        OrderToBuild = false;
        towerExisted = false;
        vectorEventChannel.OnReachRemoveListener(PlaceBuilding);
    }
    public void MoveExistTower(Building building)
    {
        this.building = building;
        building.enabled = false;
        towerExisted = true;
        previousPos = new Vector2Int((int)building.transform.position.x, (int)building.transform.position.z);
        SetCoord(previousPos, 1);
        TextureSetActive(true);
    }
    public void BuildNewTower(Building building)
    {
        if (this.building != null && texture.isActiveAndEnabled)
        {
            DestroyTower();
        }
        TextureSetActive(true);
        this.building = building;
        building.enabled = false;
        GridPlacement();
    }
    private void DestroyTower()
    {
        if (towerExisted)
        {
            TextureSetActive(false);
            SetCoord(previousPos, 0);
            buildingTransform.position = new Vector3Int(previousPos.x, 6, previousPos.y);
            OnDone?.Invoke();
        }
        else
        {
            Destroy(building.gameObject);
            TextureSetActive(false);
        }
        building = null;
        towerExisted = false;
        touchScript.enabled = true;
    }
    private void TextureSetActive(bool state)
    {
        texture.gameObject.SetActive(state);
    }
    public int GetCoord(int x, int y)
    {
        return Grid[x, y];
    }
    public void DestroyBuilding(Transform _transform)
    {
        SetCoord(new Vector2Int((int)_transform.position.x, (int)_transform.position.z), 1);
    }
    public void AddListener(Action action)
    {
        OnDone += action;
    }
    public void RemoveListener(Action action)
    {
        OnDone -= action;
    }
    private void OnDisable()
    {
        gridChannel.DestroyRemoveListener(DestroyBuilding);
    }
}
