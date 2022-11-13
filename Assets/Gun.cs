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

    private float cooldownTimer = 0;

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDelta = mousePos - transform.position;

        float angle = Mathf.Atan2 (mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);


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
    }
}
