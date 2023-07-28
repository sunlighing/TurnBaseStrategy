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

        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    public void SetUnitAtGridPosition(GridPositon gridPositon,Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPositon);
        gridObject.SetUnit(unit);
    }

    public Unit GetUnitAtGridPosition(GridPositon gridPositon)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPositon);
        return gridObject.GetUnit(); ;
    }

    public void ClearUnitAtGridPosition(GridPositon gridPositon)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPositon);
        gridObject.SetUnit(null);
    }
}
