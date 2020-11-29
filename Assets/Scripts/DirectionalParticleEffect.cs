using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalParticleEffect : MonoBehaviour
{
    [SerializeField] private GameObject particles;

    public void SpawnParticles(Vector2Int direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        Vector3 rotation = new Vector3(0, 0, angle);

        Instantiate(particles, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(rotation));
    }
}
