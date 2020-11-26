using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror_Reflect_UR : MonoBehaviour, ILazerDirection
{
    public Vector2 LazerDirection(Vector2 inputDirection)
    {
        if (inputDirection == Vector2.up)
            return Vector2.right;
        else if (inputDirection == Vector2.right)
            return Vector2.up;
        else
            return Vector2.zero;
    }
}
