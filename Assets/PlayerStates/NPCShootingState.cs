using System.Collections;
using UnityEngine;

public class NPCShootingState : AbstractNPCState
{
    private Coroutine rollingRoutine = null;
    private Vector2 lastMovementInput = Vector2.right;

    public NPCShootingState(ShooterNPC owner) : base(owner) { }

    public override void Apply() { }
    public override void ShootStarted() => Owner.Gun.ShotGun();
    public override void ShootReleased() => Owner.Gun.ReleaseShot();
    public override void Roll() => Owner.StartCoroutine(RollRoutine());
    public override void Reload() => Owner.Gun.TransitionToState(GunHandler.GunStates.Reloading);

    public override void Move(Vector2 axis)
    {
        if(rollingRoutine != null) return;

        bool isMoving = Vector3.Distance(Vector3.zero, axis) > 0.001f;
        Vector2 input = axis * Owner.MovementSpeed * Time.deltaTime;

        if (isMoving)
        {
            lastMovementInput = input.normalized;
        }
        
        Owner.transform.Translate(input);
    }

    public override void ListenAim(Vector2 aimPosition)
    {
        Owner.GunRotator.RotateGun(aimPosition);
        Owner.Gun.SetAimDirection(aimPosition);
    }

    private IEnumerator RollRoutine()
    {
        Vector3 currentPosition = Owner.transform.position;
        Vector2 rollPosition = currentPosition + (Vector3)lastMovementInput * Owner.RollDistance;

        Owner.SetImmunity(true);
        Owner.SetTouchable(false);
        Owner.SetColor(Color.yellow);
        
        while (Vector3.Distance(currentPosition, rollPosition) > 0.001f)
        {
            currentPosition = Vector3.MoveTowards(currentPosition, rollPosition, Owner.RollSpeed * Time.deltaTime);
            
            yield return null;
        }

        Owner.SetImmunity(false);
        Owner.SetTouchable(true);
        Owner.SetColor(Color.white);
        
        rollingRoutine = null;
    }
}
