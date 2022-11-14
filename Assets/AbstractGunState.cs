public abstract class AbstractGunState : IGunState
{
    public Gun Gun { get; set; }
    
    public void Setup(Gun gun)
    {
        Gun = gun;
        RefreshState();
    }

    public abstract void UpdateState(float deltaTime);
    public abstract void RefreshState();
    public abstract void OnActionExecuted();
    public abstract void OnActionReleased();
}