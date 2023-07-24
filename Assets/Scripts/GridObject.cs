using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    private GridSystem gridSystem;
    private GridPositon gridPositon;

    public GridObject(GridSystem gridSystem, GridPositon gridPositon)
    {
        this.gridSystem = gridSystem;
        this.gridPositon = gridPositon;
    }
}
