using UnityEngine;
using System.Collections;
public class HoleTrigger : MonoBehaviour
{
    // Reference to the ball's Rigidbody
    public GameObject ball;  // Drag and drop your ball GameObject in the Inspector
    public HoleInfoUI holeInfoUI;
    private Vector3 originalPosition;
    private GolfPuttSound golfPuttSound;


    // Start is called before the first frame update
    void Start()
    {
        // Store the original position of the ball at the start of the game
        originalPosition = ball.transform.position;

        // Get the AudioSource component attached to this object
        golfPuttSound = ball.GetComponent<GolfPuttSound>();
    }

    // Event when an object enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the ball
        if (other.CompareTag("Player"))
        {
            // Play the cup sound immediately
            if (golfPuttSound != null)
            {
                golfPuttSound.BallInTheCupSound();
            }


            // Call the next function to hold the ball in the cup for sound to finish
            StartCoroutine(PlayNiceShotAfterDelay());
            StartCoroutine(ResetBallWithDelay());
        }
    }

    private IEnumerator PlayNiceShotAfterDelay()
    {
        // Wait 4 seconds for cup sound to finish
        yield return new WaitForSeconds(0.75f);

        // Play "Nice Shot" sound
        if (golfPuttSound != null)
        {
            golfPuttSound.NiceShot();
        }

        // Wait for the Nice Shot sound to finish
        yield return new WaitForSeconds(golfPuttSound.NiceShotClip.length);

    }

    private IEnumerator ResetBallWithDelay()
    {
        // 4 second wait so sound plays fully
        yield return new WaitForSeconds(4.0f);

        // Reset the ball's position to the original starting position
        ball.transform.position = originalPosition;

        // Optionally, reset the ball's velocity to prevent sliding
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.linearVelocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
        }

        if (holeInfoUI != null)
        {
            holeInfoUI.ResetShots();     
        }

        // Log message or trigger any additional logic after ball reset
        Debug.Log("Ball reset to original position after 4 second delay.");
    }
}
