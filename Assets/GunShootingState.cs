public class GunShootingState : AbstractGunState
{
    private MiniTimer cooldownTimer;

    public GunShootingState(float cooldownBetweenBullets)
    {
        cooldownTimer = new MiniTimer(cooldownBetweenBullets);
    }

    protected override void RefreshState()
    {
        Gun.Cartridge.Reload();
    }
    
    public override void Update(float deltaTime)
    {
        cooldownTimer.Update(deltaTime);
    }

    public override void Shot()
    {
        if (!cooldownTimer.Finished)
        {
            return;
        }
        
        Gun.ShotBullet();
        cooldownTimer.ResetTimer();
        
        if (!Gun.Cartridge.HasBulletsToShot)
        {
            Gun.TransitionToState(Gun.GunStates.Empty);
        }
    }
}