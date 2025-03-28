using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerAttack : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        Vector3 rotation = mousePosition - transform.position;

        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    public void MousePosition(InputAction.CallbackContext context)
    {
        mousePosition = mainCam.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
