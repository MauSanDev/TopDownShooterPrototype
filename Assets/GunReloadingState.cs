
using UnityEngine;

public class GunReloadingState : AbstractGunState
{
    public GunReloadingState(float timer)
    {
        refillTimer = new MiniTimer(timer);
        refillTimer.OnTimeFinished += OnRefillCompleted;
        refillTimer.OnUpdate += OnRefilling;
    }

    private MiniTimer refillTimer;

    private void OnRefilling()
    {
        Debug.Log("Reloading...");
    }

    private void OnRefillCompleted()
    {
        Debug.Log("Bullets Refilled");
        Gun.TransitionToState(Gun.GunStates.ReadyToShot);
    }
    
    public override void Update(float deltaTime)
    {
        refillTimer.Update(deltaTime);
    }

    protected override void RefreshState()
    {
        refillTimer.ResetTimer();
    }

    public override void Shot() { }
}