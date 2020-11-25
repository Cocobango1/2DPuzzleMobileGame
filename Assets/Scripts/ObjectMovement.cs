using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 4;
    Vector2Int targetPosition;

    private void Awake()
    {
        targetPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        transform.position = (Vector2)targetPosition;
    }
    public void DefineTargetPosition(Vector2Int direction)
    {
        Vector2Int position = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
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
    }
}
