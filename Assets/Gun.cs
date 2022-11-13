using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform shootPoint = null;
    [SerializeField] private float bulletSpeed;

    [Header("Gun Configuration")] 
    [SerializeField] private float reloadCooldown = 3f;
    [SerializeField] private int bulletsPerCartridge = 10;
    [SerializeField] private int totalBullets = 10;
    [SerializeField] private AbstractShootingStrategy shootingStrategy;
    [SerializeField][Range(1,10)] private float precisionMargin = 1.4f;
    
    private Dictionary<GunStates, IGunState> gunStates = new Dictionary<GunStates, IGunState>();
    
    public GunCartridge Cartridge { get; private set; }
    
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
    
    private void RotateGun(Vector3 mouseDelta)
    {
        float angle = Mathf.Atan2 (mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private Vector3 GetMouseDelta()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        
        return direction;
    }

    public void TransitionToState(GunStates newState)
    {
        CurrentState = gunStates[newState];
        CurrentState.Setup(this);
    }
    

    private void Update()
    {
        Vector3 mouseDelta = GetMouseDelta();
        
        RotateGun(mouseDelta);
        
        CurrentState.UpdateState(Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R) && !Cartridge.IsCartridgeFull)
        {
            TransitionToState(GunStates.Reloading);
            return;
        }

        if (Input.GetMouseButton(0))
        {
            CurrentState.Shot();
        }
    }

    public void ShotBullet(Bullet bulletPrefab)
    {
        Cartridge.Consume();
        
        Vector3 direction = GetMouseDelta();
        

        direction = new Vector3(direction.x * UnityEngine.Random.Range(1, precisionMargin),
            direction.y * UnityEngine.Random.Range(1, precisionMargin), 1);
        
        Bullet instance = Instantiate(bulletPrefab, shootPoint.position, quaternion.identity);

        direction.Normalize();
        instance.Shot(direction, bulletSpeed);
    }
}
