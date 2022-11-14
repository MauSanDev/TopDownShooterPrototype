using UnityEngine;

public static class CustomExtensions
{
    public static Vector3 GetDirection(this Vector3 point, Vector3 target)
    {
        return target - point;
    }
}
