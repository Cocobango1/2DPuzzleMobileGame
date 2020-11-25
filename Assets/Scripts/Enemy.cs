using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IBlockable
{
    public void DefineTargetPosition(Vector2Int direction)
    {
        EnemyDeath();
    }

    private void EnemyDeath()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
