
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
        GunHandler.TransitionToState(GunHandler.GunStates.ReadyToShot);
    }
    
    public override void UpdateState(float deltaTime)
    {
        refillTimer.Update(deltaTime);
    }

    public override void RefreshState()
    {
        refillTimer.ResetTimer();
    }

    public override void OnActionExecuted() { }

    public override void OnActionReleased() { }
}