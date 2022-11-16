
using UnityEngine;

public class GunReloadingState : AbstractGunState
{
    public GunReloadingState(GunHandler gun) : base(gun)
    {
        refillTimer = new MiniTimer(gun.ReloadCooldown);
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
        Gun.TransitionToState(GunHandler.STATE_READY_TO_SHOT);
    }
    
    public override void UpdateState(float deltaTime)
    {
        refillTimer.Update(deltaTime);
    }

    public override void OnStateApply()
    {
        refillTimer.ResetTimer();
    }

    public override void OnActionExecuted() { }

    public override void OnActionReleased() { }
}