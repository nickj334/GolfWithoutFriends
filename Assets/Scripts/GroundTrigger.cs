using System.Collections;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    // Reference to the ball's Rigidbody
    public GameObject ball;  // Drag and drop your ball GameObject in the Inspector
    private Vector3 originalPosition;
    public AudioClip inTheCupClip;  // Drag and drop your "ball in cup" sound clip
    private AudioSource audioSource;  // AudioSource component reference

    // Start is called before the first frame update
    void Start()
    {
        // Store the original position of the ball at the start of the game
        originalPosition = ball.transform.position;
        Debug.Log("Original position of the ball: " + originalPosition);

        // Get the AudioSource component attached to this object
        audioSource = GetComponent<AudioSource>();
    }

    // Event when an object enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the ball
        if (other.CompareTag("Player"))
        {
            // Play the cup sound immediately
            if (audioSource != null && inTheCupClip != null)
            {
                audioSource.PlayOneShot(inTheCupClip);
            }

            // Call the next function to hold the ball in the cup for sound to finish
            Debug.Log("Ball has hit the ground trigger.");
            StartCoroutine(ResetBallWithDelay());
        }
    }

    private IEnumerator ResetBallWithDelay()
    {
        // 4 second wait so sound plays fully
        Debug.Log("Waiting for 4 seconds before resetting the ball...");
        yield return new WaitForSeconds(4.0f);

        Debug.Log("4 seconds passed. Resetting the ball position to: " + originalPosition);
        // Reset the ball's position to the original starting position
        //ball.transform.position = originalPosition;
        //Debug.Log("Ball's New position: " + ball.transform.position);

        // Optionally, reset the ball's velocity to prevent sliding
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.position = originalPosition; // Use Rigidbody.position to reset the position
            ballRb.linearVelocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
        }

        // Log message or trigger any additional logic after ball reset
        Debug.Log("Ball reset to original position after 4 second delay.");
    }
}
