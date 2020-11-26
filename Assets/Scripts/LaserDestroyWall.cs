using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserDestroyWall : MonoBehaviour, IReflectable
{
    [SerializeField] private UnityEvent WallDestroyEvent = new UnityEvent();

    public void StopLaser(){ }

    public void ReflectLaser(Vector2 hitNormal)
    {
        WallDestroyEvent?.Invoke();
        Destroy(gameObject, 0.8f);
    }
}
