using UnityEngine;

public class LeverSnap : MonoBehaviour
{
    [SerializeField] public Transform leverMesh; // Drag your mesh here
    [SerializeField] public float minPosition = -0.5f;
    [SerializeField] public float maxPosition = 0.5f;
    [SerializeField] public Transform fakeLeverMesh; 

    private bool isGrabbed = false;
    private Vector3 meshStartPos;
    private Vector3 handleStartPos;
    [Range(0f, 1f)] public float leverValue { get; private set; }



    void Start()
    {
        if (leverMesh != null)
            meshStartPos = leverMesh.localPosition;
        handleStartPos = transform.localPosition;
    }

    void Update()
    {
        if (leverMesh == null) return;

        if (isGrabbed)
        {
            // Update position based on handle movement while grabbed
            float handleMovement = transform.localPosition.x - handleStartPos.x;
            Vector3 meshPos = leverMesh.localPosition;
            meshPos.x = meshStartPos.x + Mathf.Clamp(handleMovement, minPosition - meshStartPos.x, maxPosition - meshStartPos.x);
            leverMesh.localPosition = meshPos;
        }

        leverValue = Mathf.InverseLerp(minPosition, maxPosition, leverMesh.localPosition.x);
    }

    // Call this when you grab the lever
    public void OnGrab()
    {
        isGrabbed = true;
    }

    // Call this when you release the lever
    public void OnRelease()
    {
        isGrabbed = false;
        fakeLeverMesh.transform.position = leverMesh.position;
    }
}