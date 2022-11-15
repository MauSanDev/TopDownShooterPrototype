using UnityEngine;

[RequireComponent(typeof(LifeHandler))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private LifeHandler lifeHandler = null;
    [SerializeField] private Collider2D mainCollider = null;
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private GunHandler gunHandler = null;
    [SerializeField] private AbstractEnemyBehaviour enemyBehaviour = null;
    [SerializeField] private GunRotator gunRotator = null;

    [SerializeField] private Transform target;
    
    public GunHandler Gun => gunHandler;
    
    private void Awake()
    {
        enemyBehaviour.Setup(this, target);
        lifeHandler.OnDeath += OnDeath;
    }
    
    private void Update()
    {
        gunRotator.RotateGun(target.position);
        enemyBehaviour.Update();
    }

    private void OnDestroy()
    {
        lifeHandler.OnDeath -= OnDeath;
    }

    private void OnDeath()
    {
        spriteRenderer.color = Color.gray;
        mainCollider.enabled = false;
    }
    
}
