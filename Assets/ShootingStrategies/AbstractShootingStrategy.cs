using UnityEngine;

[RequireComponent(typeof(GunHandler))]
public abstract class AbstractShootingStrategy : MonoBehaviour, IGunState
{
    [SerializeField] private float cooldownBetweenShots = .2f;
    protected MiniTimer CooldownTimer { get; private set; }

    private void Awake()
    {
        CooldownTimer = new MiniTimer(cooldownBetweenShots);
    }
    
    public GunHandler GunHandler { get; set; }

    public void Setup(GunHandler gunHandler)
    {
        GunHandler = gunHandler;
        RefreshState();
    }

    public void UpdateState(float deltaTime)
    {
        CooldownTimer.Update(deltaTime);
    }
    
    public void RefreshState()
    {
        GunHandler.Cartridge.Reload();
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
    public abstract void ProcessShot();
}
