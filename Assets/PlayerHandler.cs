using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LifeHandler))]
public class PlayerHandler : MonoBehaviour, IInputListener
{
    [Header("Modifiers")]
    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private float rollSpeed = 10;
    [SerializeField] private float rollDistance = 5f;
    
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private GunRotator gunRotator = null;
    [SerializeField] private GunHandler gunHandler = null;
    [SerializeField] private LifeHandler lifeHandler = null;
    [SerializeField] private Collider2D collider = null;
    
    private Vector2 lastMovementInput = Vector2.right;
    private Coroutine rollingRoutine = null;
    
    private bool IsRolling => rollingRoutine != null;

    private void Awake()
    {
        lifeHandler.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        spriteRenderer.color = Color.gray;
        gameObject.SetActive(false);
        Debug.Log("you dead");
    }
    
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

    private void SetImmunity(bool isImmune)
    {
        lifeHandler.SetImmunity(isImmune);
        collider.enabled = !isImmune;
    }

    public void ListenAim(Vector2 aimPosition)
    {
        gunRotator.RotateGun(aimPosition);
        gunHandler.SetAimDirection(aimPosition);
    }

    private IEnumerator RollRoutine()
    {
        Vector2 rollPosition = transform.position + (Vector3)lastMovementInput * rollDistance;

        SetImmunity(true);
        spriteRenderer.color = Color.yellow;
        while (Vector3.Distance(transform.position, rollPosition) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, rollPosition, rollSpeed * Time.deltaTime);
            
            yield return null;
        }

        SetImmunity(false);
        spriteRenderer.color = Color.white;
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
