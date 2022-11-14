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
    
    public void RefreshState()
    {
        Gun.Cartridge.Reload();
    }

    public void ProcessShot()
    {
        if (!CooldownTimer.Finished)
        {
            return;
        }

        ExecuteShot();
        CooldownTimer.ResetTimer();
        
        if (!Gun.Cartridge.HasBulletsToShot)
        {
            Gun.TransitionToState(Gun.GunStates.Empty);
        }
    }

    public void OnActionReleased() => OnShotEnd();
    public void OnActionExecuted()
    {
        OnShotStart();
        ProcessShot();
    }

    protected abstract void OnShotStart();
    protected abstract void OnShotEnd();
    protected abstract void ExecuteShot();
}
