using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjectArray;

    public GridSystem(int width,int height,float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width, height];

        for (int x = 0; x<width; x++)
        {
            for(int z = 0; z < height; z++)
            {
                //Debug.DrawLine(GetWorldPostion(x,z), GetWorldPostion(x,z)+Vector3.right * .2f ,Color.white,1000);
                GridPositon gridPositon = new GridPositon(x, z);
                gridObjectArray[x,z] = new GridObject(this, gridPositon);
            }
        }
    }

    public Vector3 GetWorldPostion(int x,int z)
    {
        return new Vector3(x, 0, z) * this.cellSize;
    }

    public GridPositon GetGridPosition(Vector3 worldPosition)
    {
        return new GridPositon(
          Mathf.RoundToInt(worldPosition.x / cellSize),
          Mathf.RoundToInt(worldPosition.z / cellSize)) ;
    }

    public void CreateDebugObjects(Transform debugPrefab)
    {
        for(int x = 0; x< width; x++)
        {
            for(int z = 0; z<height; z++)
            {
               Transform debugTransform =  GameObject.Instantiate(debugPrefab, GetWorldPostion(x, z), Quaternion.identity);
                debugTransform.position = new Vector3(x,0, z);
            }
        }
    }

    public GridObject GetGridObject(GridPositon gridPositon)
    {
        return gridObjectArray[gridPositon.x, gridPositon.z];
    }
}
