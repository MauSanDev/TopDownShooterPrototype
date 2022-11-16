using UnityEngine;

[RequireComponent(typeof(LifeHandler))]
[RequireComponent(typeof(Collider2D))]
public class ShooterNPC : MonoBehaviour, IInputListener
{
    [Header("Components")]
    [SerializeField] protected LifeHandler lifeHandler = null;
    [SerializeField] protected Collider2D mainCollider = null;
    [SerializeField] protected SpriteRenderer spriteRenderer = null;
    [SerializeField] protected GunHandler gunHandler = null;
    [SerializeField] protected GunRotator gunRotator = null;

    [Header("Properties")]
    [SerializeField] protected float movementSpeed = 10;
    [SerializeField] private float rollSpeed = 10;
    [SerializeField] private float rollDistance = 5f;
    
    [Header("IA")]
    [SerializeField] private AbstractNPCBehaviour behavior;

    private FiniteStateMachine<AbstractNPCState> stateMachine;
    
    public GunHandler Gun => gunHandler;
    public GunRotator GunRotator => gunRotator;
    public float MovementSpeed => movementSpeed;
    public float RollSpeed => rollSpeed;
    public float RollDistance => rollDistance;

    public void SetImmunity(bool immune) => lifeHandler.SetImmunity(immune);
    public void SetTouchable(bool isTouchable) => mainCollider.enabled = isTouchable;
    public void SetColor(Color newColor) => spriteRenderer.color = newColor;

    public const string STATE_READY_TO_SHOT = "ReadyToShot";
    public const string STATE_DEATH = "ReadyToShot";

    private void SetupStateMachine()
    {
        stateMachine = new FiniteStateMachine<AbstractNPCState>();
        stateMachine.RegisterState(STATE_READY_TO_SHOT, new NPCShootingState(this), true);
        stateMachine.RegisterState(STATE_DEATH, new NPCDeathState(this));
    }
    
    protected virtual void Awake()
    {
        SetupStateMachine();
        lifeHandler.OnDeath += OnDeath;
        behavior.Setup(this);
    }
    
    protected virtual void OnDestroy()
    {
        lifeHandler.OnDeath -= OnDeath;
    }

    protected virtual void OnDeath()
    {
        stateMachine.ApplyState(STATE_DEATH);
    }

    #region IInputListener Implementation
    public void ShootStarted() => stateMachine.CurrentState.ShootStarted();
    public void ShootReleased() => stateMachine.CurrentState.ShootReleased();
    public void Roll() => stateMachine.CurrentState.Roll();
    public void Reload() => stateMachine.CurrentState.Reload();
    public void Move(Vector2 axis) => stateMachine.CurrentState.Move(axis);
    public void ListenAim(Vector2 aimPosition) => stateMachine.CurrentState.ListenAim(aimPosition);

    #endregion
}
