using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockable 
{
   void DefineTargetPosition(Vector2Int direction);
}

public interface IReflectable
{
    void ReflectLaser(Vector3 hitNormal); 
    void StopLaser();
}
