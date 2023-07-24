using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform GridDebugObjectPrefab;

    private GridSystem gridSystem;
    void Start()
    {
        gridSystem = new GridSystem(10, 10,2f);

        gridSystem.CreateDebugObjects(GridDebugObjectPrefab);
    }


}
