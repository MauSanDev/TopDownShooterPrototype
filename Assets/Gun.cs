using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform shootPoint = null;
    [SerializeField] private Bullet bulletPrefab = null;
    [SerializeField] private float bulletSpeed;

    [Header("Gun Configuration")] 
    [SerializeField] private float cooldownBetweenShots = .2f;
    [SerializeField] private int catridgeBullets = 10;
    [SerializeField] private float refillCooldown = 3f;
    
    
    public GunCartridge Cartridge { get; private set; }
    
    public enum GunStates
    {
        ReadyToShot,
        Reloading,
        Empty
    }

    private Dictionary<GunStates, AbstractGunState> states = new Dictionary<GunStates, AbstractGunState>();

    private AbstractGunState CurrentState { get; set; }

    private void DefineStates()
    {
        states = new Dictionary<GunStates, AbstractGunState>()
        {
            {GunStates.ReadyToShot, new GunShootingState(cooldownBetweenShots)},
            {GunStates.Reloading, new GunReloadingState(refillCooldown)},
            {GunStates.Empty, new GunEmptyState()}
        };
    }
    
    
    private void Awake()
    {
        Cartridge = new GunCartridge(catridgeBullets, 100);

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
        return mousePos - transform.position;
    }

    public void TransitionToState(GunStates newState)
    {
        CurrentState = states[newState];
        CurrentState.Setup(this);
    }
    

    private void Update()
    {
        Vector3 mouseDelta = GetMouseDelta();
        
        RotateGun(mouseDelta);
        
        CurrentState.Update(Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            TransitionToState(GunStates.Reloading);
            return;
        }

        if (Input.GetMouseButton(0))
        {
            CurrentState.Shot();
        }
    }

    public void ShotBullet()
    {
        Cartridge.Consume();
        
        Vector3 mouseDelta = GetMouseDelta();
        
        Bullet instance = Instantiate(bulletPrefab, shootPoint.position, quaternion.identity);

        Vector3 direction = mouseDelta - transform.position;
        direction.Normalize();
        instance.Shot(direction, bulletSpeed);
    }
}
