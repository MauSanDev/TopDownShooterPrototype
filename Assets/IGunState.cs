public interface IGunState
{
    Gun Gun { get; set; }
    void UpdateState(float deltaTime);
    void RefreshState();
    void Setup(Gun gun);
    void OnActionExecuted();
    void OnActionReleased();
}