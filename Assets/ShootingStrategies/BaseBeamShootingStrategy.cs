using UnityEngine;

public class BaseBeamShootingStrategy : AbstractShootingStrategy
{
    [SerializeField] private LineRenderer lineRenderer;

    public override void ProcessShot()
    {
        if (CooldownTimer.Finished)
        {
            Gun.Cartridge.Consume();
            CooldownTimer.ResetTimer();
        }

        ExecuteShot();
        
        if (!Gun.Cartridge.HasBulletsToShot)
        {
            OnShotEnd();
            Gun.TransitionToState(Gun.GunStates.Empty);
        }
    }

    protected override void ExecuteShot()
    {
        Vector3 muzzlePosition = Gun.Muzzle.position;
        Vector3 direction = Gun.GetAimDelta();
        
        RaycastHit2D hit = Physics2D.Raycast(muzzlePosition, direction);
        lineRenderer.SetPosition(0, muzzlePosition);

        if (hit.collider != null)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            Debug.LogWarning($"{GetType()} :: {gameObject.name} beam didn't found a target!");
            lineRenderer.SetPosition(1, direction * 10);
        }
    }

    protected override void OnShotStart()
    {
        lineRenderer.gameObject.SetActive(true);
    }

    protected override void OnShotEnd()
    {
        lineRenderer.gameObject.SetActive(false);
    }
}