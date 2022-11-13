using UnityEngine;

public class NormalShootingStrategy : AbstractShootingStrategy
{
    [SerializeField] private float cooldownBetweenShots = .2f;
    [SerializeField] private Bullet bulletPrefab;
    
    private MiniTimer cooldownTimer;

    private void Awake()
    {
        cooldownTimer = new MiniTimer(cooldownBetweenShots);
    }

    public override void RefreshState()
    {
        Gun.Cartridge.Reload();
    }

    public override void UpdateState(float deltaTime)
    {
        cooldownTimer.Update(deltaTime);
    }

    public override void Shot()
    {
        if (!cooldownTimer.Finished)
        {
            return;
        }
        
        Gun.ShotBullet(bulletPrefab);
        cooldownTimer.ResetTimer();
        
        if (!Gun.Cartridge.HasBulletsToShot)
        {
            Gun.TransitionToState(Gun.GunStates.Empty);
        }
    }
}