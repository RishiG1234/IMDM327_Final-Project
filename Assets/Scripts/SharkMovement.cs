using UnityEngine;
using UnityEngine.InputSystem;

public class SharkMovement : MonoBehaviour
{
    [Header("Movement")]
    public float swimSpeed;
    public float turnSpeed = 60f;
    public float boostSpeed;

    [Header("Input Actions")]
    public InputActionProperty moveAction;
    public InputActionProperty turnAction;
    public InputActionProperty boostAction;

    [Header("References")]
    public Transform cameraTransform;

    void Update()
    {
        Vector2 move = moveAction.action.ReadValue<Vector2>();
        Vector2 turn = turnAction.action.ReadValue<Vector2>();

        bool boost = boostAction.action.IsPressed();
        float currentSpeed = boost ? boostSpeed : swimSpeed;

        // Forward swimming
        Vector3 forward = cameraTransform.forward;
        forward.y = 0; // no vertical movement
        forward.Normalize();

        transform.position += forward * move.y * currentSpeed * Time.deltaTime;

        // Rotation (yaw)
        transform.Rotate(0, turn.x * turnSpeed * Time.deltaTime, 0);
    }
}
