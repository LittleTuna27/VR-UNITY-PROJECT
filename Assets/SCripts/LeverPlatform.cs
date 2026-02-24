using UnityEngine;

public class LeverPlatform : MonoBehaviour
{
    [SerializeField] private LeverSnap lever;
    [SerializeField] private Vector3 positionA; // start pos (local)
    [SerializeField] private Vector3 positionB; // end pos (local)
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private bool snapToEnds = true; // optional: snap or follow exactly

    private Vector3 targetPosition;

    void Update()
    {
        if (lever == null) return;

        targetPosition = Vector3.Lerp(positionA, positionB, lever.leverValue);

        if (snapToEnds)
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
        else
            transform.localPosition = targetPosition; // follows lever exactly, no smoothing
    }
}