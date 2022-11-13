using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform shootPoint = null;
    [SerializeField] private Bullet bulletPrefab = null;
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDelta = mousePos - transform.position;

        float angle = Mathf.Atan2 (mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);


        if (Input.GetMouseButtonDown(0))
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
    }
}
