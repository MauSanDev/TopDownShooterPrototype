public abstract class AbstractGunState : IGunState
{
    public GunHandler Gun { get; set; }

    public AbstractGunState(GunHandler gun)
    {
        Gun = gun;
    }

    public abstract void UpdateState(float deltaTime);
    public abstract void OnStateApply();
    public abstract void OnActionExecuted();
    public abstract void OnActionReleased();
}