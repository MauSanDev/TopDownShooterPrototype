using UnityEngine;

public class GunEmptyState : AbstractGunState
{
    public GunEmptyState(GunHandler gun) : base(gun) { }
    
    public override void UpdateState(float deltaTime) { }

    public override void OnStateApply() { }

    public override void OnActionExecuted()
    {
        if (Gun.Cartridge.HasBulletsToLoad)
        {
            Gun.TransitionToState(GunHandler.STATE_RELOADING);
        }
        else
        {
            Debug.LogWarning("You don't have more shots!");
        }
    }

    public override void OnActionReleased() { }

}