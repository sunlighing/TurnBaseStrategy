using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private int width;
    private int height;
    private float cellSize;

    public GridSystem(int width,int height,float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        for (int x = 0; x<width; x++)
        {
            for(int z = 0; z < height; z++)
            {
                Debug.DrawLine(GetWorldPostion(x,z), GetWorldPostion(x,z)+Vector3.right * .2f ,Color.white,1000);
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
          Mathf.RoundToInt(worldPosition.x / cellSize)  ,
            worldPosition.z / cellSize) ;
    }
}
