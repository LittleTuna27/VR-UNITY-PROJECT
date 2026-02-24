using UnityEngine;

public class CrankSnap : MonoBehaviour
{
    [SerializeField] public int snapPositions = 4;
    [SerializeField] public float snapStrength = 10f;

    private Rigidbody rb;
    private float snapAngle;
    private bool isGrabbed = false;

    void Start()
    {
        if (!TryGetComponent<Rigidbody>(out rb))
        {
            Debug.LogError($"CrankSnap requires a Rigidbody on '{name}'. Add one in the Inspector.");
            enabled = false; // avoid NullReference in FixedUpdate
            return;
        }

        snapAngle = 360f / Mathf.Max(1, snapPositions);

        //var grabInteractable = GetComponent<GrabInteractable>();
       // if (grabInteractable != null)
       // {
          //  grabInteractable.WhenSelected.AddListener(() => isGrabbed = true);
           // grabInteractable.WhenUnselected.AddListener(() => isGrabbed = false);
        //}
    }

    void FixedUpdate()
    {
        if (isGrabbed || rb == null) return;

        float currentAngle = transform.localEulerAngles.y;
        float nearestSnap = Mathf.Round(currentAngle / snapAngle) * snapAngle;
        float diff = Mathf.DeltaAngle(currentAngle, nearestSnap);

        if (Mathf.Abs(diff) > 0.5f)
        {
            rb.angularVelocity = Vector3.up * (diff * snapStrength * Time.deltaTime);
        }
    }
}
