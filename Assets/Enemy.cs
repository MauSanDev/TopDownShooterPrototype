using UnityEngine;

public class Enemy : AbstractShooterNPC
{
    [SerializeField] private AbstractEnemyBehaviour enemyBehaviour = null;
    [SerializeField] private Transform target;

    protected override void Awake()
    {
        base.Awake();
        enemyBehaviour.Setup(this, target);
    }
    
    private void Update()
    {
        gunRotator.RotateGun(target.position);
        enemyBehaviour.Update();
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        mainCollider.enabled = false;
    }
}
