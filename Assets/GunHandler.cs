using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
    [SerializeField] private Transform gunMuzzle = null;
    [SerializeField] private float bulletSpeed;

    [Header("Gun Configuration")] 
    [SerializeField] private float reloadCooldown = 3f;
    [SerializeField] private int bulletsPerCartridge = 10;
    [SerializeField] private int totalBullets = 10;
    [SerializeField] private AbstractShootingStrategy shootingStrategy;
    [SerializeField][Range(1,10)] private float precisionMargin = 1.4f;
    
    private Dictionary<GunStates, IGunState> gunStates = new Dictionary<GunStates, IGunState>();

    private bool isShooting = false;

    public Transform Muzzle => gunMuzzle;
    
    public GunCartridge Cartridge { get; private set; }

    public float BulletSpeed => bulletSpeed;
    public float PrecisionMargin => precisionMargin;
    
    public enum GunStates
    {
        ReadyToShot,
        Reloading,
        Empty
    }

    private IGunState CurrentState { get; set; }

    private void DefineStates()
    {
        gunStates = new Dictionary<GunStates, IGunState>()
        {
            {GunStates.ReadyToShot, shootingStrategy},
            {GunStates.Reloading, new GunReloadingState(reloadCooldown)},
            {GunStates.Empty, new GunEmptyState()}
        };
    }

    private void Awake()
    {
        Cartridge = new GunCartridge(bulletsPerCartridge, totalBullets);

        DefineStates();
        TransitionToState(GunStates.ReadyToShot);
    }

    public void TransitionToState(GunStates newState)
    {
        CurrentState = gunStates[newState];
        CurrentState.Setup(this);
    }
    
    private void Update()
    {
        CurrentState.UpdateState(Time.deltaTime);

        if (isShooting)
        {
            CurrentState.OnActionExecuted();
        }
    }

    public void ShotGun()
    {
        CurrentState.OnActionExecuted();
        isShooting = true;
    }

    public void ReleaseShot()
    {
        isShooting = false;
        CurrentState.OnActionReleased();
    }

    public void SetAimDirection(Vector2 aimPosition)
    {
        AimDirection = transform.position.GetDirection(aimPosition);
    }
    
    public Vector2 AimDirection { get; private set; }
}
