using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    private GridSystem gridSystem;
    private GridPositon gridPositon;
    private Unit unit;

    public GridObject(GridSystem gridSystem, GridPositon gridPositon)
    {
        this.gridSystem = gridSystem;
        this.gridPositon = gridPositon;
    }

    public override string ToString()
    {
        return gridPositon.ToString();
    }

    public void SetUnit(Unit unit)
    {
        this.unit = unit;
    }

    public Unit GetUnit()
    {
        return unit;
    }
}
