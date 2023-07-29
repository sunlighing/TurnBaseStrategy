using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;

    private GridObject gridObject = null;

    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
        textMeshPro.text = this.gridObject.ToString();
    }

    private void Update()
    {

        textMeshPro.text = this.gridObject.ToString();
    }
}
