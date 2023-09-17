using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UnityActionSystem : MonoBehaviour
{
    public static UnityActionSystem Instance
    {
        get;
        private set;

    }
    public event EventHandler OnSelectedUnitChanged;

    [SerializeField] private Unit selecteUnit;
    [SerializeField] private LayerMask unitLayerMask;


    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There's more one UnitActionSystem"+transform+" - "+Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
      
     
        if (Input.GetMouseButtonDown(0))
        {
            if (TryHanldeUnitSelection())
            {
                return;
            }
            selecteUnit.GetMoveAction().Move(MouseWorld.GetPosition());
        }
    }

    private bool TryHanldeUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask))
        {
            if(raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
        }

        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selecteUnit = unit;
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit()
    {
        return selecteUnit;
    }
}
