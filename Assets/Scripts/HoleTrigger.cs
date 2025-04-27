using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    // Reference to the ball's Rigidbody
    public GameObject ball;  // Drag and drop your ball GameObject in the Inspector
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Store the original position of the ball at the start of the game
        originalPosition = ball.transform.position;
    }

    // Event when an object enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the ball
        if (other.CompareTag("Player"))
        {
            // Reset the ball's position to the original position
            ball.transform.position = originalPosition;

            // Optionally, you can reset the ball's velocity to prevent it from sliding
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                ballRb.linearVelocity = Vector3.zero;  // Stop any motion
                ballRb.angularVelocity = Vector3.zero;  // Stop any rotation
            }

            // Log message or trigger any additional logic you want here
            Debug.Log("Ball reset to the original position!");
        }
    }
}
