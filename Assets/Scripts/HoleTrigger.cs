using UnityEngine;
using System.Collections;
public class HoleTrigger : MonoBehaviour
{
    // Reference to the ball's Rigidbody
    public GameObject ball;  // Drag and drop your ball GameObject in the Inspector
    public HoleInfoUI holeInfoUI;  // this is for counter
    private Vector3 originalPosition; // this is for reseting ball position
    private GolfPuttSound golfPuttSound;  // this is for all sound calls


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
            StartCoroutine(PlayCommentAfterDelay ());
            StartCoroutine(ResetBallWithDelay());
        }
    }

    private IEnumerator PlayCommentAfterDelay()
    {
        yield return new WaitForSeconds(0.75f); // Let cup sound finish

        if (golfPuttSound != null && golfPuttSound.BallInTheCupClips.Length > 0)
        {
            int index = Random.Range(0, golfPuttSound.BallInTheCupClips.Length);
            AudioClip selectedClip = golfPuttSound.BallInTheCupClips[index];

            golfPuttSound.audioSource.PlayOneShot(selectedClip);

            // Wait for the comment clip to finish before continuing
            yield return new WaitForSeconds(selectedClip.length);
        }
    }

    private IEnumerator ResetBallWithDelay()
    {
        // 4 second wait so sound plays fully
        yield return new WaitForSeconds(4.0f);

        // Reset the ball's position to the original starting position
        //ball.transform.position = originalPosition;

        // Optionally, reset the ball's velocity to prevent sliding
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.position = originalPosition; // Use Rigidbody.position to reset the position
            ballRb.linearVelocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
        }


        // counter reset
        if (holeInfoUI != null)
        {
            holeInfoUI.ResetShots();     
        }

        // Log message or trigger any additional logic after ball reset
        Debug.Log("Ball reset to original position after 4 second delay.");
    }
}
