using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform shootPoint = null;
    [SerializeField] private Bullet bulletPrefab = null;
    [SerializeField] private float bulletSpeed;

    [Header("Gun Configuration")] 
    [SerializeField] private float cooldownBetweenShots = .2f;
    [SerializeField] private bool resetCooldownOnShotRelease = false;
    [SerializeField] private int catridgeBullets = 10;
    [SerializeField] private float refillCooldown = 3f;

    private bool isRefilling = false;
    private float refillTimer = 0;
    private float cooldownTimer = 0;
    private int currentBullets = 0;

    private void Awake()
    {
        currentBullets = catridgeBullets;
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDelta = mousePos - transform.position;

        float angle = Mathf.Atan2 (mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (isRefilling)
        {
            Debug.Log("Refilling...");
            refillTimer -= Time.deltaTime;

            if (refillTimer <= 0)
            {
                isRefilling = false;
                currentBullets = catridgeBullets;
                Debug.Log("Bullets Refilled");
            }
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRefilling = true;
            refillTimer = refillCooldown;
            return;
        }
        
        
        if (currentBullets == 0)
        {
            Debug.LogWarning("You don't have bullets, press R");
            
            return;
        }
        

        if (Input.GetMouseButtonUp(0) && resetCooldownOnShotRelease)
        {
            cooldownTimer = 0;
        }
        
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            return;
        }
        

        if (Input.GetMouseButton(0))
        {
            ShotBullet(mouseDelta);
        }
    }

    public void ShotBullet(Vector3 mouseDelta)
    {
        Bullet instance = Instantiate(bulletPrefab, shootPoint.position, quaternion.identity);

        Vector3 direction = mouseDelta - transform.position;
        direction.Normalize();
        instance.Shot(direction, bulletSpeed);

        cooldownTimer = cooldownBetweenShots;
        currentBullets--;
    }
}
