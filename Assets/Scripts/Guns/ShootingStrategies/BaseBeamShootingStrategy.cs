using UnityEngine;

public class BaseBeamShootingStrategy : AbstractShootingStrategy, ILifeHitCollider
{
    [SerializeField] private float beamDamageCooldown =.1f;
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
            Gun.TransitionToState(GunHandler.STATE_EMPTY);
        }
    }

    protected override void ExecuteShot()
    {
        Vector3 muzzlePosition = Gun.Muzzle.position;
        Vector3 direction = Gun.AimDirection;
        
        RaycastHit2D hit = Physics2D.Raycast(muzzlePosition, direction);
        lineRenderer.SetPosition(0, muzzlePosition);

        if (hit.collider == null)
        {
            Debug.LogWarning($"{GetType()} :: {gameObject.name} beam didn't found a target!");
            lineRenderer.SetPosition(1, direction * 10);
            return;
        }

        if (hit.collider.TryGetComponent(out IHitListener handler))
        {
            handler.OnHitReceived(this);
        }
        lineRenderer.SetPosition(1, hit.point);
    }

    protected override void OnShotStart()
    {
        lineRenderer.gameObject.SetActive(true);
    }

    protected override void OnShotEnd()
    {
        lineRenderer.gameObject.SetActive(false);
    }

    public float DamageCooldown => beamDamageCooldown;

}