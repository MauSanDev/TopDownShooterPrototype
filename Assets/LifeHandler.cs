using System;
using UnityEngine;

public class LifeHandler : MonoBehaviour
{
    [SerializeField] private int lifePoints;

    [SerializeField] private LayerMask damageLayer;

    public event Action OnDeath;

    public bool IsAlive => lifePoints > 0;

    private void AddDamage(int amount = 1)
    {
        if(!IsAlive) return;

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
}
