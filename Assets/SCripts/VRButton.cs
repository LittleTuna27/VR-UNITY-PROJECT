using UnityEngine;
using Unity.XR.CoreUtils;

public class ThirdPersonVR : MonoBehaviour
{
    [SerializeField] private XROrigin xrOrigin;
    [SerializeField] private Camera thirdPersonCamera;
    [SerializeField] private Transform playerBody; // your character, not XR Origin
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 2f, -3f);
    [SerializeField] private float followSpeed = 5f;

    private Camera vrCamera;
    private bool isThirdPerson = false;

    void Start()
    {
        vrCamera = xrOrigin.Camera;
        thirdPersonCamera.gameObject.SetActive(false); // start in VR mode
    }

    void Update()
    {
        if (!isThirdPerson) return;

        // Follow the player smoothly, fixed behind them
        Vector3 targetPos = playerBody.position + playerBody.TransformDirection(cameraOffset);
        thirdPersonCamera.transform.position = Vector3.Lerp(
            thirdPersonCamera.transform.position,
            targetPos,
            followSpeed * Time.deltaTime
        );

        // Always look at the player
        thirdPersonCamera.transform.LookAt(playerBody.position + Vector3.up);
    }

    public void EnterThirdPerson()
    {
        isThirdPerson = true;
        vrCamera.gameObject.SetActive(false);
        thirdPersonCamera.gameObject.SetActive(true);
    }

    public void ExitThirdPerson()
    {
        isThirdPerson = false;
        vrCamera.gameObject.SetActive(true);
        thirdPersonCamera.gameObject.SetActive(false);
    }
}