using UnityEngine;

public class RespawnPlane : MonoBehaviour
{
    public Transform spawnPoint;
    public CameraZoneMover cameraMover;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a player
        if (spawnPoint != null)
        {
            Debug.LogWarning("IT WORKS SPAWNPOINT>>>>>>>>>>>");
            var cc = other.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;


            other.transform.position = spawnPoint.position;

            if (cc != null) cc.enabled = true;
        }
            
        else
            Debug.LogWarning("RespawnPlane: No spawn point assigned!");

        // Snap camera back to zone 0
        if (cameraMover != null)
        {
            cameraMover.MoveToZone(0);
            Debug.LogWarning("IT WORKS CAMERA>>>>>>>>>>>");
        }
            
        else
            Debug.LogWarning("RespawnPlane: No CameraZoneMover assigned!");
    }
}