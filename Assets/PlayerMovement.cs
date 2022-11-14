using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IInputListener
{
    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private float rollSpeed = 10;
    [SerializeField] private SpriteRenderer spriteRenderer = null;

    private Coroutine rollingRoutine = null;

    [SerializeField] private float rollDistance = 5f;
    private Vector3 rollPosition = Vector3.zero;
    private Vector2 lastInput = Vector2.right;

    [SerializeField] private GunHandler gunHandler = null;

    private bool IsRolling => rollingRoutine != null;

    private IEnumerator RollRoutine()
    {
        rollPosition = transform.position + (Vector3)lastInput * rollDistance;

        spriteRenderer.color = Color.yellow;
        while (Vector3.Distance(transform.position, rollPosition) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, rollPosition, rollSpeed * Time.deltaTime);
            
            yield return null;
        }

        spriteRenderer.color = Color.white;
        rollingRoutine = null;
    }

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position + (Vector3)lastInput * rollDistance;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pos, 1f);
    }
    
    #endif
    public void Shoot()
    {
        Debug.Log("Shoot");
    }

    public void Roll()
    {
        rollingRoutine = StartCoroutine(RollRoutine());
    }

    public void Move(Vector2 axis)
    {
        if(IsRolling) return;

        bool isMoving = Vector3.Distance(Vector3.zero, axis) > 0.001f;
        Vector2 input = axis * movementSpeed * Time.deltaTime;

        if (isMoving)
        {
            lastInput = input.normalized;
        }
        
        transform.Translate(input);
    }
}
