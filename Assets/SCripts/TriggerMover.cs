using UnityEngine;

public class CameraZoneTrigger : MonoBehaviour
{
    [SerializeField] private CameraZoneMover cameraMover;
    [SerializeField] private int zoneIndex; // 0 for first trigger, 1 for second, etc.
    [SerializeField] private bool returnOnExit = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            cameraMover.MoveToZone(zoneIndex);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && returnOnExit)
            cameraMover.ReturnToStart();
    }
}