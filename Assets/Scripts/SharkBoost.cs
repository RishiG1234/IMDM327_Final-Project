using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;


public class SharkBoost : MonoBehaviour
{
public InputActionProperty boostAction;  // A button
    public ContinuousMoveProvider moveProvider;  
    public float normalSpeed = 1.5f;
    public float boostSpeed = 4f;

    void Update()
    {
        // Read A button
        bool boosting = boostAction.action.IsPressed();

        // Read joystick from the move provider (same input it uses)
        Vector2 input = moveProvider.leftHandMoveInput.inputAction.ReadValue<Vector2>();
        bool movingForward = input.y > 0.1f;

        // Apply boost only when A is held AND joystick forward
        if (boosting && movingForward)
            moveProvider.moveSpeed = boostSpeed;
        else
            moveProvider.moveSpeed = normalSpeed;
    }
}
