using UnityEngine;

public class DifferentFirstBulletShootingStrategy : BaseGunShootingStrategy
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Bullet firstBulletPrefab;

    protected override Bullet GetBulletPrefab() => GunHandler.Cartridge.IsCartridgeFull ? firstBulletPrefab : bulletPrefab;
    
    protected override void OnShotStart() { }
    protected override void OnShotEnd() { }
}
