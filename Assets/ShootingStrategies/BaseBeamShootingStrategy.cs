using UnityEngine;

public class BaseBeamShootingStrategy : AbstractShootingStrategy
{
    [SerializeField] private LineRenderer lineRenderer;

    protected override void OnShotStart()
    {
        lineRenderer.gameObject.SetActive(true);
    }

    protected override void OnShotEnd()
    {
        lineRenderer.gameObject.SetActive(false);
    }

    protected override void ExecuteShot()
    {
        Gun.ShotRay(lineRenderer);
    }
}