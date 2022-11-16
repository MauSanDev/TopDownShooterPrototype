using UnityEngine;

public class NormalShootingStrategy : BaseGunShootingStrategy
{
    [SerializeField] private Bullet bulletPrefab;

    protected override Bullet GetBulletPrefab() => bulletPrefab;
    
    protected override void OnShotStart() { }
    protected override void OnShotEnd() { }
}