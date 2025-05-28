using UnityEngine;

public class CupAttractor : MonoBehaviour
{
    public Transform targetPoint; // Assign this in Inspector
    public float attractionForce = 10f; // Force strength
    public string ballTag = "Player"; // Ball tag to detect

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(ballTag))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null && targetPoint != null)
            {
                Vector3 direction = (targetPoint.position - other.transform.position).normalized;
                rb.AddForce(direction * attractionForce);
            }
        }
    }
}