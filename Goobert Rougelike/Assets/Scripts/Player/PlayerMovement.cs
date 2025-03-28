using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private new Rigidbody2D rigidbody;
    private Vector2 movementInput;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.linearVelocity = movementInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
