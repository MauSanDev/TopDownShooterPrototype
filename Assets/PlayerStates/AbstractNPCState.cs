using UnityEngine;

public abstract class AbstractNPCState : IInputListener
{
    protected AbstractNPCState(ShooterNPC owner)
    {
        Owner = owner;
    }
    
    protected ShooterNPC Owner { get; }

    public abstract void Apply();
    public abstract void ShootStarted();
    public abstract void ShootReleased();
    public abstract void Roll();
    public abstract void Reload();
    public abstract void Move(Vector2 axis);
    public abstract void ListenAim(Vector2 aimPosition);
}
