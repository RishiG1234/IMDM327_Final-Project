using UnityEngine;
using UnityEngine.InputSystem;

public class SharkMovement : MonoBehaviour
{
    [Header("Movement")]
    public float swimSpeed = 3f;
    public float boostSpeed = 6f;
    public float turnSpeed = 60f;

    [Header("Input")]
    public InputActionProperty moveAction;   // Left joystick
    public InputActionProperty boostAction;  // A/X button (optional)

    private Transform head;     // From XR Origin Camera

    void Start()
    {
        // Find the VR camera (the direction we swim in)
        head = Camera.main.transform;
    }

    void Update()
    {
        SwimMovement();
        TurnMovement();
    }

    void SwimMovement()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        // Forward swimming: use vertical axis of joystick
        float forward = moveInput.y;

        float speed = boostAction.action.IsPressed() ? boostSpeed : swimSpeed;

        Vector3 direction = head.forward;
        direction.y = 0; // Prevent swimming up/down accidentally
        direction.Normalize();

        transform.position += direction * forward * speed * Time.deltaTime;
    }

    void TurnMovement()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        float turn = moveInput.x;

        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
    }
}
