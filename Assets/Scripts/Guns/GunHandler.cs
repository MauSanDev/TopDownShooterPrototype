using UnityEngine;

public class GunHandler : MonoBehaviour
{
    public const string STATE_READY_TO_SHOT = "ReadyToShot";
    public const string STATE_RELOADING = "Reloading";
    public const string STATE_EMPTY = "Empty";
    
    [SerializeField] private Transform gunMuzzle = null;
    [SerializeField] private float bulletSpeed;

    [Header("Gun Configuration")] 
    [SerializeField] private float reloadCooldown = 3f;
    [SerializeField] private int bulletsPerCartridge = 10;
    [SerializeField] private int totalBullets = 10;
    [SerializeField] private AbstractShootingStrategy shootingStrategy;
    [SerializeField][Range(1,10)] private float precisionMargin = 1.4f;

    private FiniteStateMachine<IGunState> stateMachine;

    private bool isShooting = false;

    public float ReloadCooldown => reloadCooldown;

    public Transform Muzzle => gunMuzzle;
    
    public GunCartridge Cartridge { get; private set; }

    public float BulletSpeed => bulletSpeed;
    public float PrecisionMargin => precisionMargin;
    
    private void DefineStates()
    {
        stateMachine = new FiniteStateMachine<IGunState>();
        
        shootingStrategy.Setup(this);
        stateMachine.RegisterState(STATE_READY_TO_SHOT, shootingStrategy, true);
        stateMachine.RegisterState(STATE_RELOADING, new GunReloadingState(this));
        stateMachine.RegisterState(STATE_EMPTY, new GunEmptyState(this));
    }

    private void Awake()
    {
        Cartridge = new GunCartridge(bulletsPerCartridge, totalBullets);
        DefineStates();
    }

    public void TransitionToState(string stateId)
    {
        ReleaseShot();
        stateMachine.ApplyState(stateId);
    }

    public bool IsReloading => stateMachine.CurrentStateId is STATE_RELOADING;
    
    private void Update()
    {
        stateMachine.CurrentState.UpdateState(Time.deltaTime);

        if (isShooting)
        {
            stateMachine.CurrentState.OnActionExecuted();
        }
    }

    public void ShotGun()
    {
        stateMachine.CurrentState.OnActionExecuted();
        isShooting = true;
    }

    public void ReleaseShot()
    {
        isShooting = false;
        stateMachine.CurrentState.OnActionReleased();
    }

    public void SetAimDirection(Vector2 aimPosition)
    {
        AimDirection = transform.position.GetDirection(aimPosition);
    }
    
    public Vector2 AimDirection { get; private set; }
}
