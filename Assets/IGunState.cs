public interface IGunState
{
    GunHandler GunHandler { get; set; }
    void UpdateState(float deltaTime);
    void RefreshState();
    void Setup(GunHandler gunHandler);
    void OnActionExecuted();
    void OnActionReleased();
}