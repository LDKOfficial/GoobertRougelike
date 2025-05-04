using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;
    private new Rigidbody2D rigidbody;
    private Vector2 movementInput;

    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.linearVelocity = movementInput * stats.moveSpeed;
        
        if(movementInput.x != 0 || movementInput.y != 0)
        {
                animator.SetTrigger("Move");
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
