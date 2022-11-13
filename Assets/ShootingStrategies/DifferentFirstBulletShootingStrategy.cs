using UnityEngine;

public class DifferentFirstBulletShootingStrategy : AbstractShootingStrategy
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Bullet firstBulletPrefab;
    
    public override void RefreshState()
    {
        Gun.Cartridge.Reload();
    }

    public override Bullet GetBulletPrefab() => Gun.Cartridge.IsCartridgeFull ? firstBulletPrefab : bulletPrefab;
}
