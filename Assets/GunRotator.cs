using UnityEngine;

public class GunRotator : MonoBehaviour
{
    private void Update() => RotateGun();
    
    private void RotateGun()
    {
        Vector3 mouseDelta = transform.position.GetMouseDelta();
        float angle = Mathf.Atan2 (mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
