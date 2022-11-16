using System;
using UnityEngine;

public class LifeHandler : MonoBehaviour, IHitListener
{
    [SerializeField] private int lifePoints = 10;
    [SerializeField] private float damageCooldown = .2f;
    [SerializeField] private LayerMask damageLayer;

    private MiniTimer hitDamageTimer;

    private bool isImmune = false;
    
    public event Action OnDeath;

    public void SetImmunity(bool immune) => isImmune = immune;

    public bool IsAlive => lifePoints > 0;

    private void Awake()
    {
        hitDamageTimer = new MiniTimer(damageCooldown, true);
    }

    private void Update()
    {
        hitDamageTimer.Update(Time.deltaTime);
    }

    private bool CanReceiveDamage => hitDamageTimer.Finished;

    private void AddDamage(int amount = 1)
    {
        if(!IsAlive || isImmune || !CanReceiveDamage) return;

        lifePoints -= amount;
        
        if (lifePoints <= 0)
        {
            OnDeath?.Invoke();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if((other.gameObject.layer & (1 << damageLayer)) != 0) return;

        AddDamage();
    }

    public void OnHitReceived(IHitCollider collider)
    {
        if (collider is ILifeHitCollider lifeHitCollider)
        {
            hitDamageTimer.SetTime(lifeHitCollider.DamageCooldown);
            
            AddDamage();
            hitDamageTimer.ResetTimer();
        }
    }
}

public interface ILifeHitCollider : IHitCollider
{
    float DamageCooldown { get; }
}