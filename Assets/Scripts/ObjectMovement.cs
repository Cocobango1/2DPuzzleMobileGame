using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour, IBlockable
{
    public float speed = 4;
    Vector2Int targetPosition;
    private bool objectBlocked = false;

    private void Awake()
    {
        targetPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        transform.position = (Vector2)targetPosition;
    }

    public void DefineTargetPosition(Vector2Int direction)
    {
        Vector2Int position = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        objectBlocked = GetComponent<FindObject>().CheckArea(position + direction, Vector2Int.zero);
        if (!objectBlocked)
            targetPosition = position + direction;
    }

    private void MoveTowardsTargetPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void Update()
    {
        var moving = (Vector2)transform.position != targetPosition;

        if (moving)
        {
            MoveTowardsTargetPosition();
        }
        else
        {
            GetComponent<LayerOrder>().SetlayerOrder();
        }
    }
}
