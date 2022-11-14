using UnityEngine;
using UnityEngine.InputSystem;

public static class CustomExtensions
{
    public static Vector3 GetMouseDelta(this Vector3 point)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 direction = mousePos - point;
        
        return direction;
    }
}
