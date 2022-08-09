using MazeInfinite;
using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField] public GameObject left;
    [SerializeField] public GameObject right;
    [SerializeField] public GameObject up;
    [SerializeField] public GameObject down;

    public void Execute(Cell cell)
    {
        right.SetActive(!cell.Right);
        down.SetActive(!cell.Bottom);
    }
}
