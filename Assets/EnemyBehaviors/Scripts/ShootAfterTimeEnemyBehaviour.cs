using UnityEngine;

[CreateAssetMenu(fileName = "ShootAfterTimeEnemyBehaviour", menuName = "Enemy Behaviors/Shoot After Time Behaviour")]
public class ShootAfterTimeEnemyBehaviour : AbstractEnemyBehaviour
{
    [SerializeField] private float shotAfterTime = 2f;
    private MiniTimer shotTimer;

    protected override void OnSetup()
    {
        shotTimer = new MiniTimer(shotAfterTime);
    }

    public override void Update()
    {
        shotTimer.Update(Time.deltaTime);
        
        Owner.Gun.SetAimDirection(Target.position);

        if(Owner.Gun.IsCharging)
            return;
        
        if (ShouldChargeGun)
        {
            Owner.Gun.TransitionToState(GunHandler.GunStates.Reloading);
            return;
        }
        
        if (shotTimer.Finished)
        {
            Owner.Gun.ShotGun();
            Owner.Gun.ReleaseShot();
            shotTimer.ResetTimer();
        }
    }

}
