public abstract class AbstractGunState : IGunState
{
    public GunHandler GunHandler { get; set; }
    
    public void Setup(GunHandler gunHandler)
    {
        GunHandler = gunHandler;
        RefreshState();
    }

    public abstract void UpdateState(float deltaTime);
    public abstract void RefreshState();
    public abstract void OnActionExecuted();
    public abstract void OnActionReleased();
}