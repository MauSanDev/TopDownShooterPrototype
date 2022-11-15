using UnityEngine;

public abstract class AbstractEnemyBehaviour : ScriptableObject
{
    protected Enemy Owner { get; private set; }
    protected Transform Target { get; private set; }
    
    protected bool ShouldChargeGun => Owner.Gun.Cartridge.HasBulletsToLoad && !Owner.Gun.Cartridge.HasBulletsToShot;

    
    public void Setup(Enemy owner, Transform target = null)
    {
        Target = target;
        Owner = owner;
        OnSetup();
    }

    protected abstract void OnSetup();
    
    public abstract void Update();
}
