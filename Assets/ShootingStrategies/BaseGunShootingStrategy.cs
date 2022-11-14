using Unity.Mathematics;
using UnityEngine;

public abstract class BaseGunShootingStrategy : AbstractShootingStrategy
{
    protected abstract Bullet GetBulletPrefab();

    public override void ProcessShot()
    {
        if (!CooldownTimer.Finished)
        {
            return;
        }

        ExecuteShot();
        CooldownTimer.ResetTimer();
        
        if (!GunHandler.Cartridge.HasBulletsToShot)
        {
            GunHandler.TransitionToState(GunHandler.GunStates.Empty);
        }
    }

    protected override void ExecuteShot()
    {
        GunHandler.Cartridge.Consume();

        Bullet bulletPrefab = GetBulletPrefab();
        Vector3 muzzlePosition = GunHandler.Muzzle.position;
        Vector3 direction = GetBulletDirection();

        Bullet instance = Instantiate(bulletPrefab, muzzlePosition, quaternion.identity);

        direction.Normalize();
        instance.Shot(direction, GunHandler.BulletSpeed);
    }

    private Vector3 GetBulletDirection()
    {
        Vector3 direction = GunHandler.transform.position.GetMouseDelta();
        float newX = direction.x * UnityEngine.Random.Range(1, GunHandler.PrecisionMargin);
        float newY = direction.y * UnityEngine.Random.Range(1, GunHandler.PrecisionMargin);
        return new Vector3(newX, newY, 1);
    }
}