using UnityEngine;

public class CupAttractor : MonoBehaviour
{
    public float attractionForce = 10f; // Adjust the strength
    public string ballTag = "Player"; // Tag of the ball object

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(ballTag))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (transform.position - other.transform.position).normalized;
                rb.AddForce(direction * attractionForce);
            }
        }
    }
}
