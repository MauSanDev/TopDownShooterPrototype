public interface IGunState : IFiniteState
{
    GunHandler Gun { get; set; }
    void UpdateState(float deltaTime);
    void OnActionExecuted();
    void OnActionReleased();
}