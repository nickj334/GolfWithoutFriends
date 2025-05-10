using System.Collections;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    // Reference to the ball's Rigidbody
    public GameObject ball;  // Drag and drop your ball GameObject in the Inspector
    public Vector3 lastPosition;
    private GolfPuttSound golfPuttSound;

    //setting flag for ground contact
    private bool hasTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        // Store the original position of the ball at the start of the game
        lastPosition = ball.transform.position;
        Debug.Log("Original position of the ball: " + lastPosition);

        // Get the AudioSource component attached to this object
        golfPuttSound = ball.GetComponent<GolfPuttSound>();
    }

    // Event when an object enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            Debug.Log("Ball has hit the ground trigger.");

            if (golfPuttSound != null)
            {
                golfPuttSound.PlayRandomGroundComment();
            }

            StartCoroutine(ResetBallWithDelay());
        }
    }

    private IEnumerator ResetBallWithDelay()
    {
        // 4 second wait so sound plays fully
        Debug.Log("Waiting for 4 seconds before resetting the ball...");
        lastPosition = ball.GetComponent<GolfBallController>().lastPosition; //Immediately get the last position (prevents setting position to ground)
        yield return new WaitForSeconds(4.0f);

        Debug.Log("4 seconds passed. Resetting the ball position to: " + lastPosition);
        // Reset the ball's position to the original starting position
        //ball.transform.position = originalPosition;
        //Debug.Log("Ball's New position: " + ball.transform.position);

        // Optionally, reset the ball's velocity to prevent sliding
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.position = lastPosition; // Use Rigidbody.position to reset the position
            ballRb.linearVelocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
        }


        // reseting trigger
        hasTriggered = false;

        // Log message or trigger any additional logic after ball reset
        Debug.Log("Ball reset to original position after 4 second delay.");
    }
}
