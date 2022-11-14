using UnityEngine;

public static class CustomExtensions
{
    public static Vector3 GetMouseDelta(this Vector3 point)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - point;
        
        return direction;
    }
}
