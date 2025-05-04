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

    private float timeSinceAnimationStart;
    
    [SerializeField]
    private float animationLength;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.linearVelocity = movementInput * stats.moveSpeed;

        timeSinceAnimationStart += Time.deltaTime;
        
        if(movementInput.x != 0 && movementInput.y != 0)
        {
            if(timeSinceAnimationStart >= animationLength)
            {
                animator.SetTrigger("Move");
                timeSinceAnimationStart = 0;
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
