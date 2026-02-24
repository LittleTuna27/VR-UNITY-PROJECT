using UnityEngine;
using UnityEngine.InputSystem;

public class InputTester : MonoBehaviour
{

    public InputActionReference JoystickInput;
    Vector2 JoysticValue = Vector2.zero;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        JoystickInput.action.Enable();

        JoystickInput.action.performed += HandleJoystickInput;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void HandleJoystickInput(InputAction.CallbackContext context)
    {
        JoysticValue = context.ReadValue<Vector2>();
    }

    private void OnGUI()
        {
        GUILayout.Label("Move the joystick to see input values in the console.");
    }
}
