using StarterAssets;
using UnityEngine;
using UnityEngine.XR;

public class ThirdPersonVRCharacterController : MonoBehaviour
{
    Vector2 moveVector;
    float triggerValue;
    bool jumpInput;
    bool jumpInputLastFrame;

    public StarterAssetsInputs inputs;

    private void Update()
    {
        var leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        var rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out moveVector);
        rightController.TryGetFeatureValue(CommonUsages.trigger, out triggerValue);
        rightController.TryGetFeatureValue(CommonUsages.primaryButton, out jumpInput);

        if (inputs != null)
        {
            inputs.MoveInput(moveVector);
            inputs.SprintInput(triggerValue != 0);

            // only fire jump on the frame the button is first pressed, not held
            if (jumpInput && !jumpInputLastFrame)
                inputs.JumpInput(true);
            else
                inputs.JumpInput(false);
        }

        jumpInputLastFrame = jumpInput;
    }
}