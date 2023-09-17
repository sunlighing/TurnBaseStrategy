using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
   
    private GridPositon gridPositon;
    private MoveAction moveAction;

    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
    }


    private void Start()
    {
        gridPositon = LevelGrid.Instance.GetGridPositon(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPositon,this);
    }

    // Update is called once per frame
    void Update()
    {
       
        /// if (Input.GetMouseButtonDown(0))
        // {
        //      Move(MouseWorld.GetPosition());
        // }
     //   gridPositon = LevelGrid.Instance.GetGridPositon(transform.position);

        GridPositon newgridPositon = LevelGrid.Instance.GetGridPositon(transform.position);
        if(newgridPositon != gridPositon)
        {
            LevelGrid.Instance.UnitMoveGridPosition(this, gridPositon, newgridPositon);
            gridPositon = newgridPositon;
        }
    }

    public MoveAction GetMoveAction()
    {
        return moveAction;
    }
}
