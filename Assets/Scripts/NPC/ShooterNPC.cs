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
    
    private AbstractNPCState currentState;
    
    public GunHandler Gun => gunHandler;
    public GunRotator GunRotator => gunRotator;
    public float MovementSpeed => movementSpeed;
    public float RollSpeed => rollSpeed;
    public float RollDistance => rollDistance;

    public void SetImmunity(bool immune) => lifeHandler.SetImmunity(immune);
    public void SetTouchable(bool isTouchable) => mainCollider.enabled = isTouchable;
    public void SetColor(Color newColor) => spriteRenderer.color = newColor;
    
    protected virtual void Awake()
    {
        lifeHandler.OnDeath += OnDeath;
        currentState = new NPCShootingState(this);
        behavior.Setup(this);
    }
    
    protected virtual void OnDestroy()
    {
        lifeHandler.OnDeath -= OnDeath;
    }

    protected virtual void OnDeath()
    {
        currentState = new NPCDeathState(this);
        currentState.Apply();
    }

    #region IInputListener Implementation
    public void ShootStarted() => currentState.ShootStarted();
    public void ShootReleased() => currentState.ShootReleased();
    public void Roll() => currentState.Roll();
    public void Reload() => currentState.Reload();
    public void Move(Vector2 axis) => currentState.Move(axis);
    public void ListenAim(Vector2 aimPosition) => currentState.ListenAim(aimPosition);

    #endregion
}
