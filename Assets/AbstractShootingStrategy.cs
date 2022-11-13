using UnityEngine;

[RequireComponent(typeof(Gun))]
public abstract class AbstractShootingStrategy : MonoBehaviour, IGunState
{
    public Gun Gun { get; set; }

    public void Setup(Gun gun)
    {
        Gun = gun;
        RefreshState();
    }

    public abstract void UpdateState(float deltaTime);

    public abstract void RefreshState();
    public abstract void Shot();
}
