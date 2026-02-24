using UnityEngine;

public class CameraZoneMover : MonoBehaviour
{
    [SerializeField] private Transform cameraToMove;
    [SerializeField] private Transform[] zonePositions; // one position per zone
    [SerializeField] private float moveSpeed = 3f;

    private Transform targetZone;
    private Vector3 startPosition;
    private bool returningToStart = false;

    void Start()
    {
        // Remember where the camera started (zone 0 / default position)
        startPosition = cameraToMove.position;
    }

    void Update()
    {
        if (returningToStart)
        {
            cameraToMove.position = Vector3.MoveTowards(
                cameraToMove.position,
                startPosition,
                moveSpeed * Time.deltaTime
            );

            if (cameraToMove.position == startPosition)
                returningToStart = false;
        }
        else if (targetZone != null)
        {
            cameraToMove.position = Vector3.MoveTowards(
                cameraToMove.position,
                targetZone.position,
                moveSpeed * Time.deltaTime
            );
        }
    }

    public void MoveToZone(int zoneIndex)
    {
        returningToStart = false;

        if (zoneIndex == 0)
        {
            // Zone 0 means return to the original start position
            ReturnToStart();
            return;
        }

        if (zoneIndex >= 0 && zoneIndex < zonePositions.Length)
            targetZone = zonePositions[zoneIndex];
    }

    public void ReturnToStart()
    {
        targetZone = null;
        returningToStart = true;
    }
}