using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform teleportTarget; // Where the player/ball should be sent
    public string objectTag = "Player"; // The tag of the object allowed to teleport

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Something entered the portal: {other.name}");

        if (other.CompareTag(objectTag))
        {
            Debug.Log($"Teleporting {other.name} to {teleportTarget.position}");

            // Move the object to the target position
            other.transform.position = teleportTarget.position;

            // Reset velocity if it has a Rigidbody
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("Resetting Rigidbody velocity");
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        else
        {
            Debug.Log($"Object tag '{other.tag}' does not match required tag '{objectTag}'");
        }
    }
}
