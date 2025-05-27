using System.Collections;
using UnityEngine;

public class fireTrigger : MonoBehaviour
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

            Debug.Log("Ball has hit the fire trigger.");

            if (golfPuttSound != null)
            {
                golfPuttSound.PlayRandomGroundComment();
            }

            StartCoroutine(ResetBall());
        }
    }

    private IEnumerator ResetBall()
    {
        
        Debug.Log("Resetting the ball...");
        lastPosition = ball.GetComponent<GolfBallController>().lastPosition; //Immediately get the last position (prevents setting position to ground)

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
        Debug.Log("Ball reset to previous position.");

        yield return null;
    }
}
