using UnityEngine;

public class laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform laserHit;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        Debug.DrawLine(transform.position, hit.point);   
    }
}
