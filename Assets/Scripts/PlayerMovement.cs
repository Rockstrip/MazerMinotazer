using System.Collections;
using MazeInfinite;
using UnityEngine;

[RequireComponent(typeof(MazeGenerator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    private bool canMove = true;
    private MazeGenerator mazeGenerator;

    private void Awake()
    {
        mazeGenerator = GetComponent<MazeGenerator>();
    }

    void Update()
    {
        if (!canMove) return;

        if (Input.GetKey(KeyCode.W))
        {
            canMove = false;
            var curCell = Cell.AtPoint((int) transform.position.x, (int) transform.position.z);
            var direction = transform.forward;
            direction = MazeGenerator.Round(direction);
            direction.y = 0;

            var open = 
                       direction == Vector3.right && curCell.Right ||
                       direction == Vector3.back && curCell.Bottom ||
                       direction == Vector3.left && Cell.AtPoint((int) transform.position.x-1, (int) transform.position.z).Right ||
                       direction == Vector3.forward && Cell.AtPoint((int) transform.position.x, (int) transform.position.z+1).Bottom;

            if (open)
                StartCoroutine(Move(transform.forward));
            else
                canMove = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Rotate(-90));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(Rotate(90));
        }
    }

    private IEnumerator Move(Vector3 to)
    {
        canMove = false;

        var start = transform.position;
        to += start;
        var time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(start, to, time / duration);
            yield return null;
        }
        
        transform.position = MazeGenerator.Round(transform.position);
        mazeGenerator.UpdateMaze();
        
        canMove = true;
    }
    private IEnumerator Rotate(float angle)
    {
        canMove = false;

        var start = transform.rotation;
        var time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            if (time > duration)
                time = duration;
            
            transform.rotation = start * Quaternion.Euler(Vector3.up * angle * time/duration);

            yield return null;
        }
        canMove = true;
    }
}
