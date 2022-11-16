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
        
        if (!Gun.Cartridge.HasBulletsToShot)
        {
            Gun.TransitionToState(GunHandler.STATE_EMPTY);
        }
    }

    protected override void ExecuteShot()
    {
        Gun.Cartridge.Consume();

        Bullet bulletPrefab = GetBulletPrefab();
        Vector3 muzzlePosition = Gun.Muzzle.position;
        Vector3 direction = GetBulletDirection();

        Bullet instance = Instantiate(bulletPrefab, muzzlePosition, quaternion.identity);

        direction.Normalize();
        instance.Shot(direction, Gun.BulletSpeed);
    }

    private Vector3 GetBulletDirection()
    {
        Vector3 direction = Gun.AimDirection;
        float newX = direction.x * UnityEngine.Random.Range(1, Gun.PrecisionMargin);
        float newY = direction.y * UnityEngine.Random.Range(1, Gun.PrecisionMargin);
        return new Vector3(newX, newY, 1);
    }
}