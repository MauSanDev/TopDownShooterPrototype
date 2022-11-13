using UnityEngine;

[RequireComponent(typeof(Gun))]
public abstract class AbstractShootingStrategy : MonoBehaviour, IGunState
{
    [SerializeField] private float cooldownBetweenShots = .2f;
    protected MiniTimer CooldownTimer { get; private set; }

    private void Awake()
    {
        CooldownTimer = new MiniTimer(cooldownBetweenShots);
    }
    
    public Gun Gun { get; set; }

    public void Setup(Gun gun)
    {
        Gun = gun;
        RefreshState();
    }

    public void UpdateState(float deltaTime)
    {
        CooldownTimer.Update(deltaTime);
    }

    public abstract void RefreshState();

    public abstract Bullet GetBulletPrefab();
    
    public void Shot()
    {
        if (!CooldownTimer.Finished)
        {
            return;
        }

        Bullet bulletPrefab = GetBulletPrefab();
        Gun.ShotBullet(bulletPrefab);
        CooldownTimer.ResetTimer();
        
        if (!Gun.Cartridge.HasBulletsToShot)
        {
            Gun.TransitionToState(Gun.GunStates.Empty);
        }
    }
}
