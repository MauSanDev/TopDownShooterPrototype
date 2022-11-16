using UnityEngine;

public class GunRotator : MonoBehaviour
{
    public void RotateGun(Vector2 aimPosition)
    {
        Vector3 mouseDelta = transform.position.GetDirection(aimPosition);
        float angle = Mathf.Atan2 (mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
