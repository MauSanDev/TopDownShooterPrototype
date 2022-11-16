using UnityEngine;

public class TurretNPCBehaviour : AbstractNPCBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float shotAfterTime = 2f;
    private MiniTimer shotTimer;

    protected override void OnSetup()
    {
        shotTimer = new MiniTimer(shotAfterTime);
    }

    public void Update()
    {
        shotTimer.Update(Time.deltaTime);

        Vector3 targetPosition = target.position;
        
        Owner.GunRotator.RotateGun(targetPosition);
        Owner.Gun.SetAimDirection(targetPosition);

        if(Owner.Gun.IsCharging)
            return;
        
        if (Owner.Gun.Cartridge.ShouldBeCharged)
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
