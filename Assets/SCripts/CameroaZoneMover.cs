using UnityEngine;

public class CameraZoneMover : MonoBehaviour
{
    [SerializeField] private Transform cameraToMove;
    [SerializeField] private Transform[] zonePositions; // one position per zone
    private Vector3 startPosition;

    void Start()
    {
        // Remember where the camera started (zone 0 / default position)
        startPosition = cameraToMove.position;
    }

    public void MoveToZone(int zoneIndex)
    {
        if (zoneIndex == 0)
        {
            // Zone 0 means return to the original start position
            ReturnToStart();
            return;
        }

        if (zoneIndex >= 0 && zoneIndex < zonePositions.Length)
            cameraToMove.position = zonePositions[zoneIndex].position;
    }

    public void ReturnToStart()
    {
        cameraToMove.position = startPosition;
    }
}