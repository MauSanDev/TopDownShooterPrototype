using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(LifeHandler))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private LifeHandler lifeHandler;
    [SerializeField] private Collider2D collider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private GunHandler gunHandler;
    [SerializeField] private GameObject player;

    [SerializeField] private float shotAfterTime = 2f;

    private MiniTimer shotTimer;

    private void Update()
    {
        shotTimer.Update(Time.deltaTime);
        
        gunHandler.SetAimDirection(player.transform.position);

        if (shotTimer.Finished)
        {
            gunHandler.ShotGun();
            gunHandler.ReleaseShot();
            shotTimer.ResetTimer();
        }
    }

    private void Awake()
    {
        shotTimer = new MiniTimer(shotAfterTime, false);
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
