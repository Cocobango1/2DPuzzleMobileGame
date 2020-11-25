using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LayerOrder : MonoBehaviour
{
    private SpriteRenderer[] _SR;

    void Start()
    {
        _SR = GetComponentsInChildren<SpriteRenderer>();
        SetlayerOrder();
    }

    public void SetlayerOrder()
    {
        foreach (SpriteRenderer sr in _SR)
        {
            sr.sortingOrder = Mathf.RoundToInt(150 - transform.position.y);
        }
    } 
}
