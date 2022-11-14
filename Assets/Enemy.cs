using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LifeHandler lifeHandler;
    [SerializeField] private Collider2D collider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        lifeHandler.OnDeath += OnDeath;
    }

    private void OnDestroy()
    {
        lifeHandler.OnDeath -= OnDeath;
    }

    private void OnDeath()
    {
        spriteRenderer.color = Color.gray;
        collider.enabled = false;
    }
    
}
