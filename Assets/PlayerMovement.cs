using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private float rollSpeed = 10;
    [SerializeField] private SpriteRenderer spriteRenderer = null;

    private Coroutine rollingRoutine = null;

    [SerializeField] private float rollDistance = 5f;
    private Vector3 rollPosition = Vector3.zero;
    private Vector2 lastInput = Vector2.zero;
    
    
    void Update()
    {
        if(IsRolling) return;
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        bool isMoving = horizontal != 0 || vertical != 0;
        Vector2 input = new Vector2(horizontal, vertical) * movementSpeed * Time.deltaTime;

        if (isMoving)
        {
            lastInput = input.normalized;
        }
        
        transform.Translate(input);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rollingRoutine = StartCoroutine(RollRoutine());
        }
    }

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

    private void OnDrawGizmos()
    {
        Vector3 pos = transform.position + (Vector3)lastInput * rollDistance;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pos, 1f);
    }
}
