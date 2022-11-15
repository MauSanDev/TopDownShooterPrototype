using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LifeHandler))]
public class PlayerHandler : AbstractShooterNPC, IInputListener
{
    [SerializeField] private float rollSpeed = 10;
    [SerializeField] private float rollDistance = 5f;
    
    private Vector2 lastMovementInput = Vector2.right;
    private Coroutine rollingRoutine = null;
    
    private bool IsRolling => rollingRoutine != null;
    
    public void ShootStarted() => gunHandler.ShotGun();
    public void ShootReleased() => gunHandler.ReleaseShot();
    public void Roll() => rollingRoutine = StartCoroutine(RollRoutine());
    public void Reload() => gunHandler.TransitionToState(GunHandler.GunStates.Reloading);

    public void Move(Vector2 axis)
    {
        if(IsRolling) return;

        bool isMoving = Vector3.Distance(Vector3.zero, axis) > 0.001f;
        Vector2 input = axis * movementSpeed * Time.deltaTime;

        if (isMoving)
        {
            lastMovementInput = input.normalized;
        }
        
        transform.Translate(input);
    }


    public void ListenAim(Vector2 aimPosition)
    {
        gunRotator.RotateGun(aimPosition);
        gunHandler.SetAimDirection(aimPosition);
    }

    private IEnumerator RollRoutine()
    {
        Vector2 rollPosition = transform.position + (Vector3)lastMovementInput * rollDistance;
        Color previousColor = spriteRenderer.color;

        lifeHandler.SetImmunity(true);
        mainCollider.enabled = false;
        spriteRenderer.color = Color.yellow;
        
        while (Vector3.Distance(transform.position, rollPosition) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, rollPosition, rollSpeed * Time.deltaTime);
            
            yield return null;
        }

        lifeHandler.SetImmunity(false);
        mainCollider.enabled = true;
        spriteRenderer.color = previousColor;
        
        rollingRoutine = null;
    }
    

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position + (Vector3)lastMovementInput * rollDistance;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pos, 1f);
    }
#endif

}
