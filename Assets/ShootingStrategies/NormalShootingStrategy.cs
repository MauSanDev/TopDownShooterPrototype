using UnityEngine;

public class NormalShootingStrategy : AbstractShootingStrategy
{
    [SerializeField] private Bullet bulletPrefab;
    
    public override void RefreshState()
    {
        Gun.Cartridge.Reload();
    }

    public override Bullet GetBulletPrefab() => bulletPrefab;
}