using UnityEngine;
using UnityEngine.InputSystem;

public class SharkMovement : MonoBehaviour
{
    [Header("Movement")]
    public float swimSpeed = 4f;
    public float turnSpeed = 60f;

    [Header("Input Actions")]
    public InputActionProperty moveAction;
    public InputActionProperty turnAction;

    [Header("References")]
    public Transform cameraTransform;

    void Update()
    {
        Vector2 move = moveAction.action.ReadValue<Vector2>();
        Vector2 turn = turnAction.action.ReadValue<Vector2>();

        // Forward swimming
        Vector3 forward = cameraTransform.forward;
        forward.y = 0; // no vertical movement

        transform.position += forward * move.y * swimSpeed * Time.deltaTime;

        // Rotation (yaw)
        transform.Rotate(0, turn.x * turnSpeed * Time.deltaTime, 0);
    }
}
