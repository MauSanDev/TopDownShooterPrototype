using UnityEngine;

[RequireComponent(typeof(LifeHandler))]
[RequireComponent(typeof(Collider2D))]
public abstract class AbstractShooterNPC : MonoBehaviour
{
    [SerializeField] protected float movementSpeed = 10;

    [SerializeField] protected LifeHandler lifeHandler = null;
    [SerializeField] protected Collider2D mainCollider = null;
    [SerializeField] protected SpriteRenderer spriteRenderer = null;
    [SerializeField] protected GunHandler gunHandler = null;
    [SerializeField] protected GunRotator gunRotator = null;

    public GunHandler Gun => gunHandler;
    
    protected virtual void Awake()
    {
        lifeHandler.OnDeath += OnDeath;
    }
    
    protected virtual void OnDestroy()
    {
        lifeHandler.OnDeath -= OnDeath;
    }

    protected virtual void OnDeath()
    {
        gunRotator.gameObject.SetActive(false);
        gunHandler.enabled = false;
        spriteRenderer.color = Color.gray;
    }
}
