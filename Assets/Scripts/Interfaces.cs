using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockable 
{
   void DefineTargetPosition(Vector2Int direction);
}


public interface IReflectable
{
    void ReflectLaser(Vector2 hitNormal);
    void StopLaser();
}

public interface ILazerDirection
{
    Vector2 LazerDirection(Vector2 inputDirection);
}
