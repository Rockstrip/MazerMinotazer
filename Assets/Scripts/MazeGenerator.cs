using System;
using System.Collections;
using System.Collections.Generic;
using MazeInfinite;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private CellController _cellPrefab;
    private CellController[,] _cells;

    private void Awake()
    {
        Random.InitState(2);
    }

    private void Start()
    {
        _cells = new CellController[10,10];
        for (var i = 0; i < 10; i++)
            for (var j = 0; j < 10; j++) 
                _cells[i,j] = Instantiate(_cellPrefab);
        
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                UpdateMaze();
            }
        }
    }
    public void UpdateMaze()
    {
        var position = transform.position;
        var lenX = _cells.GetLength(0);
        var lenY = _cells.GetLength(1);
        var x = (int) position.x - lenX / 2;
        var z = (int) position.z - lenY / 2;
        
        for (var i = 0; i < lenX; i++)
        {
            for (var j = 0; j < lenY; j++)
            {
                _cells[i, j].transform.position = new Vector3(x + i, 0, z + j);
                _cells[i, j].Execute(Cell.AtPoint(x + i, z + j));
            }
        }
    }

    public static Vector3 Round(Vector3 vector)
    {
        var x = Mathf.RoundToInt(vector.x);
        var z = Mathf.RoundToInt(vector.z);
        return new Vector3(x, vector.y, z);
    }
}