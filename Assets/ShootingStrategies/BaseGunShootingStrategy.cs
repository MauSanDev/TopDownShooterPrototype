public abstract class BaseGunShootingStrategy : AbstractShootingStrategy
{
    protected abstract Bullet GetBulletPrefab();

    protected override void ExecuteShot()
    {
        Bullet bulletPrefab = GetBulletPrefab();
        Gun.ShotBullet(bulletPrefab);
    }
}