using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour
{
   public LayerMask layerMask;
    public bool CheckArea(Vector2Int targetPosition, Vector2Int direction)
    {
        Collider2D moveablObject = Physics2D.OverlapCircle(targetPosition, 0.1f, layerMask);

        if (moveablObject != null && moveablObject.GetComponent<IBlockable>() != null && moveablObject.gameObject != gameObject)
        {
            moveablObject.GetComponent<IBlockable>().DefineTargetPosition(direction);
            return true;
        }
        else
            return false;
    }
}
