using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror_Reflect_DL : MonoBehaviour, ILazerDirection
{
    public Vector2 LazerDirection(Vector2 inputDirection)
    {
        if (inputDirection == Vector2.down)
            return Vector2.left;
        else if (inputDirection == Vector2.left)
            return Vector2.down;
        else
            return Vector2.zero;
    }
}
