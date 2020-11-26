using UnityEngine;

public class laser : MonoBehaviour, IReflectable
{
    private LineRenderer lineRenderer;
    [SerializeField] private Vector2 direction;
    [SerializeField] private bool startBeam; 
    [SerializeField] private IReflectable reflect;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if (!startBeam)
            lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (startBeam)
            DrawRay();
    }

    public void DrawRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hit.point);

        if (hit.transform.GetComponent<IReflectable>() != null)
        {
            reflect = hit.transform.GetComponent<IReflectable>();
            reflect.ReflectLaser(hit.normal);
        }
        else if (reflect != null)
        {
            reflect.StopLaser();
        }
    }

    public void ReflectLaser(Vector2 hitNormal)
    {
        direction = GetComponent<ILazerDirection>().LazerDirection(hitNormal);
        startBeam = true;
    }
    public void StopLaser()
    {
        startBeam = false;
        lineRenderer.enabled = false;

        if (reflect != null)
            reflect.StopLaser();
    }
}
