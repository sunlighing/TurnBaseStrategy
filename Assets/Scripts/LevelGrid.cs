using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance
    {
        get;
        private set;

    }

    [SerializeField] private Transform gridDebugObjectPrefab;

    private GridSystem gridSystem;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more one UnitActionSystem" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;

        gridSystem = new GridSystem(10, 10, 3f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    public void AddUnitAtGridPosition(GridPositon gridPositon,Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPositon);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitListAtGridPosition(GridPositon gridPositon)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPositon);
        return gridObject.GetUnitList(); ;
    }

    public void RemoveUnitAtGridPosition(GridPositon gridPositon,Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPositon);
        gridObject.RemoveUnit(unit);
    }

   // public GridPositon GetGridPositon(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
    
    public void UnitMoveGridPosition(Unit unit,GridPositon fromGridPosition,GridPositon toGridPosition)
    {
        RemoveUnitAtGridPosition(fromGridPosition,unit); //清楚上个
        AddUnitAtGridPosition(toGridPosition, unit); //指定下一个
    
    }

    public GridPositon GetGridPositon(Vector3 worldPosition)
    {
        return gridSystem.GetGridPosition(worldPosition);
    }
}
